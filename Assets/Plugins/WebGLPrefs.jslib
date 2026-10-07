mergeInto(LibraryManager.library, {
    GetAllPlayerPrefsJson: function() {
        var prefs = {};
        // В WebGL Unity хранит PlayerPrefs в объекте localStorage или IndexedDB кэше.
        // Этот код собирает всё содержимое веб-хранилища игры.
        for (var i = 0; i < localStorage.length; i++) {
            var key = localStorage.key(i);
            // Unity помечает свои ключи префиксом, отсекаем или берем всё
            prefs[key] = localStorage.getItem(key);
        }
        var jsonStr = JSON.stringify(prefs);
        var bufferSize = lengthBytesUTF8(jsonStr) + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(jsonStr, buffer, bufferSize);
        return buffer;
    }
});
