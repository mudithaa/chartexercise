// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var app = angular.module('app', []);

app.controller('salesController', ['$scope', '$http', function ($scope, $http) {
    $scope.selectedCategory = "";
    $scope.categories = [];        

    function getCategories() {
        $http.get('/api/sales/categories')
            .then(function (result) {
                $scope.categories =  result.data;
            });
    };

    function getProducts(categoryName) {
        $scope.products = [];
        return $http.get('/api/sales/' + categoryName + '/products')
            .then(function (result) {
                $scope.products = result.data;
            });
    };

    $scope.changeProducts = function () {
        getProducts(this.selectedCategory);
    }
        
    $scope.init = function () {
        getCategories();
    };
}]);