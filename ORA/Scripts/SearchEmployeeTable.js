function SearchEmployeeFunction() {
    // Declare variables
    var input, filter, table, tr, td, i;
    input = document.getElementById("SearchInput");
    filter = input.value.toUpperCase();
    table = document.getElementById("EmployeeTable");
    tr = table.getElementsByTagName("tr");

    var dateFromInput, dateToInput, tdDate;
    dateFromInput = new Date($("datepicker_from").val());
    dateToInput = new Date($("datepicker_to").val());

    ;

    // Loop through all table rows, and hide those who don't match the search query
    for (i = 0; i < tr.length; i++) {
        td = tr[i].getElementsByTagName("td")[0];
        if (td) {
            if (td.innerHTML.toUpperCase().indexOf(filter) > -1) {
                tr[i].style.display = "";
            } else {
                tr[i].style.display = "none";
            }
        }
    }

    for (i = 0; i < tr.length; i++)
    {
        tdDate = new Date(tr[i].getElementById("tdDate")[0].val());
        if (tdDate.innerHTML >= dateFromInput && tdDate.innerHTML <= dateToInput)
        {
            tr[i].style.display = "";
        }
        else {
            tr[i].style.display = "none";
        }
    }
}