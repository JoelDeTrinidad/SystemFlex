(function () {
    'use strict';

    angular
        .module('BlurAdmin')
        .controller('BaseController', BaseController)

    function BaseController($state) {
        /*viewModels*/
        var vm = this;
        var loginStateName = 'security.login';
        var marketingStateName = 'security.marketing';

        //Data
        vm.hasSideBar = ($state.current.name != loginStateName && $state.current.name != marketingStateName);

        
    }
})();
