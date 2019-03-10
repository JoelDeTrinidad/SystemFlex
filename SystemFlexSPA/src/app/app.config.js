(function () {
    'use strict';

    angular.module('BlurAdmin.config', [])
      .config(routeConfig);

    /** @ngInject */
    function routeConfig($urlRouterProvider) {
        $urlRouterProvider.otherwise('/Seguridad/marketing');
    }
})();