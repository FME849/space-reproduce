mergeInto(LibraryManager.library, {
    LoginWithGoogle: function() {
        if (typeof window.auth === 'undefined') {
            console.error("Firebase auth is not initialized!");
            return;
        }

        var authProvider = new window.auth.GoogleAuthProvider();
        var appAuth = window.auth.getAuth();
        window.auth.signInWithPopup(appAuth, authProvider);
    }
})