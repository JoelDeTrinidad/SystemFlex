(function () {
    'use strict';
    angular
    .module('app.security.marketing')
    .controller('MarketingController', MarketingController)
    function MarketingController($scope, $state, $http, WEBAPI, spinnerService) {
        //Data
        var vm = this;
        $scope.myInterval = 3000;
        $scope.noWrapSlides = false;
        $scope.active = 0;
        var slides = $scope.slides = [];
        var currIndex = 0;
        //Methods
        vm.session = session;

        $scope.addSlide = function () {
           
            slides.push({
                image: 'http://cabanasencantadas.com/wp-content/uploads/2015/05/Bajada-a-El-Mirador-1024x684.jpg',
                text: ['VISTA A LA LAGUNA DE MASAYA'][slides.length % 4],
                id: currIndex++
            });
            slides.push({
                image: 'http://cabanasencantadas.com/wp-content/uploads/2015/05/Las-tres-cabanas-noche-1024x684.jpg',
                text: ['', 'VISTA DE CABAÑA'][slides.length % 4],
                id: currIndex++
            });
            slides.push({
                image: 'http://cabanasencantadas.com/wp-content/uploads/2015/05/Vista-panoramica-amanecer-1-1024x684.jpg',
                text: ['', '', 'LO QUE USTED NECESITA PARA SUS EVENTOS'][slides.length % 4],
                id: currIndex++
            });
            slides.push({
                image: 'http://i0.wp.com/cabanasencantadas.com/wp-content/uploads/2015/05/Cabana-2-balcon.jpg?resize=806%2C538',
                text: ['', '', '', 'DIFRUTE DE  UN AMBIENTE FRESCO Y AGRADABLE'][slides.length % 4],
                id: currIndex++
            });
            slides.push({
                image: 'http://cabanasencantadas.com/wp-content/uploads/2015/05/Cabana-3-sala-1024x684.jpg',
                text: ['VISITENOS Y SE CONVENCERA'][slides.length % 4],
                id: currIndex++
            });
        };

        for (var i = 0; i < 1; i++) {
            $scope.addSlide();
        }

        function session() {
            $state.go('security.login');
      
        }
        
    }

})();