(function () {
    'use strict';

    angular.module('app.security.roles_users', [])
      .config(routeConfig);

    /** @ngInject */
    function routeConfig($stateProvider) {
        $stateProvider
          .state('security.roles_users', {
              url: '/Perfil-por-usuario',
              templateUrl: 'app/pages/security/roles-users/roles-users.html',
              controller: 'RolesUsersController as vm',
              title: 'Perfil por usuario',
              sidebarMeta: {

                  order: 2,
              },
          });
    }
})();