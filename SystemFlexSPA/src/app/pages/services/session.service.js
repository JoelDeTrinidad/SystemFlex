(function () {
    'use strict';

    angular
        .module('app.services', [])
        .factory('session', session);

    /** @ngInject */
    function session($window) {

        var service = {
            setSession: setSession,
            getSession: getSession,
            removeSession: removeSession
        };

        return service;

        //////////

        function setSession(account) {
            $window.localStorage.setItem("session", JSON.stringify(account));
        }

        function getSession() {
            return JSON.parse($window.localStorage.getItem("session"));
        }

        function removeSession() {
            return $window.localStorage.removeItem("session");
        }
    }
}());