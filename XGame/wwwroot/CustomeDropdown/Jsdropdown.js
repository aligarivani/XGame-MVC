// Select DOM elements
const dropdown = document.querySelector(".dropdown1");
const select = dropdown.querySelector(".select");
const caret = dropdown.querySelector(".caret");
const menu = dropdown.querySelector(".menu1");
const options = dropdown.querySelectorAll(".menu1 li");
const selected = dropdown.querySelector(".selected");

// Toggle dropdown menu on select box click
select.addEventListener("click", () => {
    select.classList.toggle("select-clicked");
    caret.classList.toggle("caret-rotate");
    menu.classList.toggle("menu1-open");
});

// Handle option selection
options.forEach(option => {
    option.addEventListener("click", () => {
        // Update selected text
        selected.innerText = option.innerText;

        // Close dropdown
        select.classList.remove("select-clicked");
        caret.classList.remove("caret-rotate");
        menu.classList.remove("menu1-open");

        // Update active option
        options.forEach(opt => opt.classList.remove("active"));
        option.classList.add("active");
    });
});