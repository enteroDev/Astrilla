
//// Handle Button appearance on active Links
//document.addEventListener('DOMContentLoaded', function () {
//    const menuItems = document.querySelectorAll('.menuItem');

//    function setActiveMenuItem() {
//        // Get the current path without the base (Link to the currently opened site)
//        const currentPath = window.location.pathname;

//        // Iterate through menuItems to remove active class and set if matched
//        menuItems.forEach(item => {
//            const link = item.querySelector('.menuLink');
//            const linkPath = link.getAttribute('href');

//            if (linkPath === currentPath) {
//                item.classList.add('active');
//            } else {
//                item.classList.remove('active');
//            }
//        });
//    }

//    // Set active menu item on page load and after history change
//    setActiveMenuItem();
//    window.addEventListener('popstate', setActiveMenuItem);

//    // Add click event to each menu item to handle dynamic changes
//    menuItems.forEach(item => {
//        item.addEventListener('click', function () {
//            menuItems.forEach(i => i.classList.remove('active'));
//            this.classList.add('active');
//        });
//    });
//});
