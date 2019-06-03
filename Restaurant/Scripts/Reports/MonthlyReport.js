$(document).ready(function () {
    $('#dateTxtFrom').datepicker();
    $('#dateTxtTo').datepicker();
    Chart.init();
});

var Chart = {
    dataPoints: [],
    init: function () {
        var chart = new CanvasJS.Chart("chartContainer", {
            theme: "light2",
            animationEnabled: true,
            title: {
                text: "Number of Clients"
            },
            axisX: {
                title: "Date",
                interval: 1
            },
            axisY: {
                interval: 1
            },
            data: [
                {
                    type: "spline",
                    dataPoints: this.dataPoints
                }
            ]
        });
        $.post("/data/GetClientsByDate", { dtFrom: $('#dateTxtFrom').val(), dtTo: $('#dateTxtTo').val() }, function (data) {
            data.forEach(function (item) {
                Chart.dataPoints.push({
                    label: item.Date,
                    y: item.VisitorsNumber
                });
            });
            chart.render();
        });
    }
};