// Event listener to load corresponding ZodiacInformation depending on user selection and set appearance of the button to active
document.addEventListener('DOMContentLoaded', function () {
    loadZodiacInfo();
});


// Load corresponding ZodiacInformation depending on user selection and set appearance of the button to active
function loadZodiacInfo() {
    const zodiacSigns = document.querySelectorAll(".zodiacSign");

    zodiacSigns.forEach(sign => {
        sign.addEventListener("click", function () {
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

            // Set minimum height to avoid jumpy behavior
            const originalHeight = infoContainer.clientHeight;
            infoContainer.style.minHeight = `${originalHeight}px`;

            // Use AJAX to load the partial view
            fetch(`/Partial/ZodiacInformation?sign=${infoId}`)
                .then(response => response.text())
                .then(html => {
                    // Clear the content container and set the loaded content
                    infoContainer.innerHTML = html;

                    // Fill the selected content with data
                    fillZodiacInfo(infoId, infoContainer);
                })
                .catch(error => {
                    console.error('Error loading content:', error);
                    // Restore height in case of an error
                    infoContainer.style.minHeight = null;
                });
        });
    });
}

// Fill HTML with content chosen by the user
function fillZodiacInfo(sign, infoContainer) {
    fetch(`/Partial/GetZodiacInfo?id=${sign}`)
        .then(response => response.json())
        .then(data => {
            if (data.success) {
                const zodiac = data.data;
                const signLowerCase = sign.toLowerCase();

                document.getElementById(`summary-${signLowerCase}`).innerText = zodiac.summary || "No content";
                document.getElementById(`text1-${signLowerCase}`).innerText = zodiac.text1 || "No content";
                document.getElementById(`text2-${signLowerCase}`).innerText = zodiac.text2 || "No content";
                document.getElementById(`text3-${signLowerCase}`).innerText = zodiac.text3 || "No content";
                document.getElementById(`text4-${signLowerCase}`).innerText = zodiac.text4 || "No content";
                document.getElementById(`text5-${signLowerCase}`).innerText = zodiac.text5 || "No content";
                document.getElementById(`text6-${signLowerCase}`).innerText = zodiac.text6 || "No content";

                // Display the selected content after it is filled with the zodiac info texts
                const infoElement = document.getElementById(`zodiacInformation${sign}`);

                if (infoElement) {
                    infoElement.style.display = 'block';
                } else {
                    console.error("Information block not found for:", sign);
                }

                // Restore the height after the content is filled
                infoContainer.style.minHeight = null;
            } else {
                alert('Failed to load zodiac information.');
                // Restore height in case of a failure
                infoContainer.style.minHeight = null;
            }
        })
        .catch(error => {
            console.error('Error fetching data:', error);
            // Restore height in case of an error
            infoContainer.style.minHeight = null;
        });
}
