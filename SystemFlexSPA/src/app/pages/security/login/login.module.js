(function () {
    'use strict';
    angular.module('app.security.login', [])

      .config(routeConfig);

    /** @ngInject */
    function routeConfig($stateProvider) {
        $stateProvider.state('security.login', {
              url: '/login',
              templateUrl: 'app/pages/security/login/login.html',
              controller: 'LoginController as vm'
          });


    }
    //api



})();