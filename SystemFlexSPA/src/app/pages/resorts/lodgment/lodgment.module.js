(function () {
    'use strict';

    angular.module('app.resorts.lodgment', [])
    .config(routeConfig);


    function routeConfig($stateProvider) {
        $stateProvider
          .state('resorts.lodgment', {
              url: '/hospedaje',
              params:{user: null},
              templateUrl: 'app/pages/resorts/lodgment/lodgment.html',
              controller: 'LodgmentController as vm',
              title: 'Hospedaje',
              sidebarMeta: {
                  order: 1,
              },
          });
    }

})();