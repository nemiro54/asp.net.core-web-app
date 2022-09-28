const checkboxAll = document.querySelector("#checkboxAll");
const checkboxOptions = document.querySelectorAll(".user-select-option");

function selectAllCheckboxes() {
    const isChecked = checkboxAll.checked;
    for (let i = 0; i < checkboxOptions.length; i++) {
        checkboxOptions[i].checked = isChecked;
    }
}