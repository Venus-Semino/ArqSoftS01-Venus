// Esperamos a que todo el documento (HTML) termine de cargar
document.addEventListener("DOMContentLoaded", function () {

    // 1. Efecto Fade-In para el contenido principal
    // Seleccionamos la etiqueta <main> que ya viene por defecto en tu proyecto
    const mainContent = document.querySelector('main');

    if (mainContent) {
        // Ocultamos el contenido inicialmente
        mainContent.style.opacity = 0;
        // Le decimos que el cambio de opacidad tomará 0.8 segundos de forma suave
        mainContent.style.transition = "opacity 0.8s ease-in-out";

        setTimeout(() => {
            mainContent.style.opacity = 1;
        }, 100);
    }

    console.log("%c¡Sistema iniciado correctamente! ", "color: #89b4fa; font-size: 14px; font-weight: bold;");
});