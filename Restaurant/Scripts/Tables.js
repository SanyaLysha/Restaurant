$(document).ready(function () {
    loadtables();
    Table.init();
});

function loadtables() {
    $.ajax({
        url: "/data/GetFreeTables",
        type: "GET",
        success: function (data) {
            $('#tableTmpl').tmpl(data).appendTo('#listTables');
        }
    });
}
var Table = {
    init: function () {
        $('.btnBookTable').on('click', function (e) {
            $('.modal').dialog();
            $.ajax({
                url: "/data/BookTable",
                data: {},
                type: "POST",
                success: function (data) {
                    $('#tableTmpl').tmpl(data).appendTo('#listTables');
                }
            });
        });
    }
}