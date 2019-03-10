(function () {
    'use strict';

    angular.module('app.security.roles', [])
      .config(routeConfig);

    /** @ngInject */
    function routeConfig($stateProvider) {
        $stateProvider
          .state('security.roles', {
              url: '/perfiles',
              templateUrl: 'app/pages/security/roles/roles.html',
              controller: 'RolesController as vm',
              title: 'Perfiles',
              sidebarMeta: {
                  order: 1,
              },
          });
    }
})();