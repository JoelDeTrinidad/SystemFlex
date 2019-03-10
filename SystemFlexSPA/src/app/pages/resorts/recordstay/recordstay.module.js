(function () {
    'use strict';

    angular.module('app.resorts.recordstay', [])
      .config(routeConfig);


    function routeConfig($stateProvider) {
        $stateProvider
          .state('resorts.recordstay', {
              url: '/SolicitudesPendientes',
              templateUrl: 'app/pages/resorts/recordstay/recordstay.html',
              controller: 'RecordStayController as vm',
              title: 'Solict. Pendientes',
              sidebarMeta: {
                  order: 2,
              },
          });
    }
})();