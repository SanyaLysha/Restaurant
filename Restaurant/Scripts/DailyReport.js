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
                text: "Number of Sold Drinks"
            },
            axisX: {
                interval: 1
            },
            axisY: {
                interval: 1
            },
            data: [
                {
                    type: "bar",
                    dataPoints: this.dataPoints
                }
            ]
        });
        $.post("/data/GetTodaySoldDrinks", { dt: $('#dateTxt').val() },function (data) {
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
