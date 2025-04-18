window.resizeHelper = (() => {
    let dotNetHelper = null;

    const notifyResize = () => {
        const height = window.innerHeight;
        if (dotNetHelper) {
            dotNetHelper.invokeMethodAsync('OnResize', height);
        }
    };

    const resizeObserver = new ResizeObserver(() => {
        notifyResize();
    });

    return {
        registerResizeCallback: (dotNetRef) => {
            dotNetHelper = dotNetRef;

            const main = document.querySelector(".responsive-chart-container") || document.body;
            resizeObserver.observe(main); // Observe le conteneur principal

            window.addEventListener('resize', notifyResize); // Écoute les resize classiques
            notifyResize(); // Appel initial
        },

        unregisterResizeCallback: () => {
            resizeObserver.disconnect();
            window.removeEventListener('resize', notifyResize);
            dotNetHelper = null;
        },

        getAvailableHeight: () => {
            return window.innerHeight;
        }
    };
})();
