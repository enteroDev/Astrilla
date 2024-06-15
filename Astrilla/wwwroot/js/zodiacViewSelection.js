﻿
// Load corresponding ZodiacInformation depending on user selection and set appearance of the button to active
document.addEventListener("DOMContentLoaded", function () {
    const zodiacSigns = document.querySelectorAll(".zodiacSign");

    zodiacSigns.forEach(sign => {
        sign.addEventListener("click", function () {
            console.log("Clicked on:", sign.id);

            // Get the content container
            const infoContainer = document.getElementById("zodiacInfoContent");

            // Ensure the container exists
            if (!infoContainer) {
                console.error("Content container not found");
                return;
            }

            // Remove the active class from all zodiac signs
            zodiacSigns.forEach(sign => {
                sign.classList.remove("active");
            });

            // Add the active class to the clicked zodiac sign
            sign.classList.add("active");

            // Get the selected zodiac information block
            const infoId = sign.id.replace('zodiacSign', '');
            console.log("Loading content for:", infoId);

            // Use AJAX to load the partial view
            fetch(`/Partial/ZodiacInformation?sign=${infoId}`)
                .then(response => response.text())
                .then(html => {
                    // Clear the content container
                    infoContainer.innerHTML = '';

                    // Set the loaded content
                    infoContainer.innerHTML = html;

                    // Display the selected content
                    const infoElement = document.getElementById(`zodiacInformation${infoId}`);
                    if (infoElement) {
                        infoElement.style.display = 'block';
                    } else {
                        console.error("Information block not found for:", infoId);
                    }
                })
                .catch(error => console.error('Error loading content:', error));
        });
    });
});
