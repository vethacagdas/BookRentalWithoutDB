// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

document.addEventListener("DOMContentLoaded", function () {
    document.getElementById("searchInput").addEventListener("keyup", function () {
        let input = this.value.toLowerCase();
        let rows = document.querySelectorAll("#studentTable tbody tr");

        rows.forEach(row => {
            let id = row.cells[0].innerText.toLowerCase();
            let name = row.cells[1].innerText.toLowerCase();
            let surname = row.cells[2].innerText.toLowerCase();

            if (id.includes(input) || name.includes(input) || surname.includes(input)) {
                row.style.display = "";
            } else {
                row.style.display = "none";
            }
        });
    });
});
