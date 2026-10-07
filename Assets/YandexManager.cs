using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Agava.YandexGames;
using System.Runtime.InteropServices; // Обязательно для работы с JS

public class YandexManager : MonoBehaviour
{
    public static YandexManager Instance;

    // Импортируем наш JavaScript метод
    [DllImport("__Internal")]
    private static extern string GetAllPlayerPrefsJson();

    private float saveTimer = 0f;
    private const float SaveInterval = 30f; // Фоновое автосохранение раз в 30 секунд для подстраховки


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private IEnumerator Start()
    {
        yield return YandexGamesSdk.Initialize();
        Debug.Log("Яндекс SDK успешно запущен!");

        // ТОЧЕЧНОЕ ДОБАВЛЕНИЕ: Получаем язык пользователя из Яндекса
        string userLang = YandexGamesSdk.Environment.i18n.lang;
        Debug.Log("Язык пользователя в Яндексе: " + userLang);

        // Записываем его в PlayerPrefs, чтобы игра могла его использовать, если нужно
        PlayerPrefs.SetString("YandexLanguage", userLang);
        PlayerPrefs.Save();

        // Скачиваем сохранения из облака
        LoadCloudData();
    }


    private void Update()
    {
        // Бесшумно бэкапим данные раз в 30 секунд на случай долгой сессии в свободном режиме
        saveTimer += Time.deltaTime;
        if (saveTimer >= SaveInterval)
        {
            saveTimer = 0f;
            #if UNITY_WEBGL && !UNITY_EDITOR
            SaveCloudData();
            #endif
        }
    }

    private void OnApplicationFocus(bool hasFocus)
    {
        // Глушим звук при сворачивании (требование Яндекса)
        AudioListener.pause = !hasFocus;
        AudioListener.volume = hasFocus ? 1f : 0f;

        // Если игрок просто закрыл вкладку во время игры — спасаем прогресс
        #if UNITY_WEBGL && !UNITY_EDITOR
                if (!hasFocus)
                {
                    SaveCloudData();
                }
        #endif
    }


    // ==========================================
    // АВТОНОМНОЕ ОБЛАЧНОЕ СОХРАНЕНИЕ
    // ==========================================

    public void SaveCloudData()
    {
        #if UNITY_EDITOR
                return;
        #endif

        if (!YandexGamesSdk.IsInitialized) return;

        // ПРОВЕРКА ЯНДЕКСА: Можно ли работать с аккаунтом?
        // Если игрок не авторизован, мы просто сохраняем локально через PlayerPrefs.Save,
        // Яндекс сам подхватит локальный кэш браузера.
        if (!PlayerAccount.HasPersonalProfileDataPermission) return;

        PlayerPrefs.Save();

        try
        {
            string allPrefsJson = GetAllPlayerPrefsJson();

            if (!string.IsNullOrEmpty(allPrefsJson) && allPrefsJson != "{}")
            {
                PlayerAccount.SetCloudSaveData(allPrefsJson);
                Debug.Log("Облако синхронизировано!");
            }
        }
        catch (System.EntryPointNotFoundException)
        {
            Debug.LogWarning("Сохранение в облако работает только в WebGL билде!");
        }
    }

    public void LoadCloudData()
    {
        if (!YandexGamesSdk.IsInitialized) return;

        // Если у анонимного игрока нет прав на профиль — облако запрашивать нельзя.
        // Сразу запускаем игру на его локальных сохранениях PlayerPrefs!
        if (!PlayerAccount.HasPersonalProfileDataPermission)
        {
            Debug.Log("Игрок не авторизован. Запуск на локальных PlayerPrefs.");
            OnCloudDataLoaded();
            return;
        }

        PlayerAccount.GetCloudSaveData((string json) =>
        {
            if (!string.IsNullOrEmpty(json) && json != "{}")
            {
                var loadedData = JsonToDictionary(json);

                foreach (var pair in loadedData)
                {
                    if (int.TryParse(pair.Value, out int intVal))
                    {
                        PlayerPrefs.SetInt(pair.Key, intVal);
                    }
                    else if (float.TryParse(pair.Value, out float floatVal))
                    {
                        PlayerPrefs.SetFloat(pair.Key, floatVal);
                    }
                    else
                    {
                        PlayerPrefs.SetString(pair.Key, pair.Value);
                    }
                }
                PlayerPrefs.Save();
                Debug.Log("Все данные из облака успешно восстановлены!");
            }

            OnCloudDataLoaded();
        });
    }


    private void OnCloudDataLoaded()
    {
        if (MainTitleScreen.Instance != null)
        {
            MainTitleScreen.Instance.RefreshUIFromCloud();
        }
    }

    // ==========================================
    // РЕКЛАМА
    // ==========================================

    public void ShowInterstitial()
    {
        if (!YandexGamesSdk.IsInitialized) return;

        InterstitialAd.Show(
            onOpenCallback: () => AudioListener.pause = true,
            onCloseCallback: (bool wasShown) => AudioListener.pause = false,
            onErrorCallback: (string error) => AudioListener.pause = false
        );
    }

    public void ShowRewarded(System.Action onRewardGranted)
    {
        if (!YandexGamesSdk.IsInitialized) return;

        VideoAd.Show(
            onOpenCallback: () => AudioListener.pause = true,
            onRewardedCallback: () => {
                onRewardGranted?.Invoke();
            },
            onCloseCallback: () => AudioListener.pause = false,
            onErrorCallback: (string error) => AudioListener.pause = false
        );
    }

    // Простой парсер JSON
    private Dictionary<string, string> JsonToDictionary(string json)
    {
        Dictionary<string, string> dict = new Dictionary<string, string>();
        json = json.Replace("{", "").Replace("}", "").Replace("\"", "");
        string[] fields = json.Split(',');
        foreach (string field in fields)
        {
            string[] pair = field.Split(':');
            if (pair.Length == 2) dict.Add(pair[0].Trim(), pair[1].Trim());
        }
        return dict;
    }
}
