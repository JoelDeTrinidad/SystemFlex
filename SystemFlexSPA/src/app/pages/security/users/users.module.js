(function () {
    'use strict';
    angular.module('app.security.users', [])

      .config(routeConfig);

    /** @ngInject */
    function routeConfig($stateProvider) {
        $stateProvider
          .state('security.users', {
              url: '/usuarios',
              templateUrl: 'app/pages/security/users/users.html',
              controller: 'UsersController as vm',
              title: 'Usuarios',
              sidebarMeta: {
                  
                  order: 0,
              },
              
          });
        
    }
    //api
  
       

})();