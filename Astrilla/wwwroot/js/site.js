

// Handle Header Fade-out on scrolling
//document.addEventListener("DOMContentLoaded", function () {
//    const webTitle = document.querySelector(".webTitle");
//    const menuBar = document.querySelector(".menuBar");

//    if (webTitle && menuBar) {
//        window.addEventListener("scroll", function () {
//            const scrollY = window.scrollY;

//            // Adjust the fade out thresholds
//            const webTitleFadeStart = 50;
//            const webTitleFadeEnd = 100;
//            const menuBarFadeStart = 100;
//            const menuBarFadeEnd = 200;

//            // Calculate the opacity for webTitle
//            let webTitleOpacity = 1;
//            if (scrollY > webTitleFadeStart) {
//                webTitleOpacity = 1 - (scrollY - webTitleFadeStart) / (webTitleFadeEnd - webTitleFadeStart);
//            }
//            webTitleOpacity = Math.max(webTitleOpacity, 0);
//            webTitle.style.opacity = webTitleOpacity;

//            // Calculate the opacity for menuBar
//            let menuBarOpacity = 1;
//            if (scrollY > menuBarFadeStart) {
//                menuBarOpacity = 1 - (scrollY - menuBarFadeStart) / (menuBarFadeEnd - menuBarFadeStart);
//            }
//            menuBarOpacity = Math.max(menuBarOpacity, 0);
//            menuBar.style.opacity = menuBarOpacity;
//        });
//    } else {
//        console.error("webTitle or menuBar not found");
//    }
//});
