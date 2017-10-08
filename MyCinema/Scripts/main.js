
console.log("webpack ok");

import Vue from "vue";
import Home from '../Areas/Home/Index.vue';
import App from "./app.vue";

const NotFound = { template: '<p>Page not found</p>' }

const routes = {
    '/': Home,
    '/about': 'About'
}
//Vue.component('currently-playing-section', require('../Areas/Home/Views/CurrentlyPlayingSection/CurrentlyPlayingSection.vue'));
//Vue.component('movie-preview-item', require('../Areas/Home/Views/MoviePreview/MoviePreview.vue'));ue.component('currently-playing-section', require('../Areas/Home/Views/CurrentlyPlayingSection/CurrentlyPlayingSection.vue'));
//ue.component('movie-preview-item', require('../Areas/Home/Views/MoviePreview/MoviePreview.vue'));

Vue.component('my-component',
    {
        template: '<div>A custom component!</div>'
    });



const v = new Vue({
    el: '#app',
    data: {
        message: 'Hello Vue.js!',
        currentRoute: window.location.pathname
    },
    computed: {
        ViewComponent() {
            const matchingView = routes[this.currentRoute];

            console.log(this.currentRoute)
            return matchingView
                ? Home
                : NotFound
        }
    },
    render(h) { return h(this.ViewComponent) },
    components: { App }

})