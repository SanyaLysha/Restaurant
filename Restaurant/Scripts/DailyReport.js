$(document).ready(function () {
    $('#dateTxt').datepicker();
    Chart.init();

});

var Chart = {
    dataPoints: [],
    init: function () {
        var chart = new CanvasJS.Chart("chartContainer", {
            theme: "light2",
            animationEnabled: true,
            title: {
                text: "Basic Column Chart"
            },
            data: [
                {
                    type: "column",
                    dataPoints: this.dataPoints
                }
            ]
        });
        $.getJSON("/data/GetTodaySoldDrinks", function (data) {
            data.forEach(function (item) {
                Chart.dataPoints.push({
                    label: item.Name,
                    y: item.Number
                });
            });
            chart.render();
        });
    }
};
