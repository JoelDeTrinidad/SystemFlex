(function () {
    'use strict';

    angular.module('BlurAdmin', [
      'ngAnimate',
      'ui.bootstrap',
      'ui.sortable',
      'ui.router',
      'ngTouch',
      'toastr',
      'smart-table',
      "xeditable",
      'ui.slimscroll',
      'ngJsTree',
      'angular-progress-button-styles',
      'angularSpinners',
     
      'BlurAdmin.theme',
      'BlurAdmin.pages',
      'BlurAdmin.config',
      'app.constants'
     
    ]);
})();