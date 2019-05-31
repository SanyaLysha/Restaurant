$(document).ready(function () {
    loadUsers();
    loadStaff();
});

function loadUsers() {
    $.ajax({
        url: "/data/GetUsers",
        type: "GET",
        success: function (data) {
            $('#userTmpl').tmpl(data).appendTo('#UsersTable');
        }
    });
}
function loadStaff() {
    $.ajax({
        url: "/data/GetStaff",
        type: "GET",
        success: function (data) {
            $('#staffTmpl').tmpl(data).appendTo('#StaffTable');
        }
    });
}
