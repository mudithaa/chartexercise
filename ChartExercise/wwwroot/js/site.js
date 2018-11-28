// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var app = angular.module('app', []);

app.controller('salesController', ['$scope', '$http', function ($scope, $http) {
    $scope.selectedCategory = "";
    $scope.categories = [];        
    $scope.sales = [];
    $scope.selectedProduct = {};

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

    function getSales(productId) {
        $scope.sales = [];
        return $http.get('/api/sales/' + productId)
            .then(function (result) {
                $scope.sales = result.data;
                $(document).ready(createChart);
                
            });
    };

    $scope.changeCategory = function () {
        getProducts(this.selectedCategory);
    }

    $scope.selectProduct = function () {
        getSales(this.selectedProduct);
    }
        
    $scope.init = function () {
        getCategories();
        
    };

    function createChart() {
        $("#chart").kendoChart({
            dataSource: {
                data: this.sales
            },
            legend: {
                visible: false
            },
            seriesDefaults: {
                type: "column",
                labels: {
                    visible: true,
                    background: "transparent"
                }
            },
            series: [{
                field: "totalSalesValue",
                categoryField: "salesDate",
                colorField: "userColor"
            }],
            valueAxis: {
                max: 28,
                majorGridLines: {
                    visible: false
                },
                visible: false
            },
            categoryAxis: {
                majorGridLines: {
                    visible: false
                },
                line: {
                    visible: false
                }
            }
        });
    }
}]);

