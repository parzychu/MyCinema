
console.log("webpack ok");

import Vue from "vue";
import VueRouter from "vue-router";
Vue.use(VueRouter);
import Home from '../Areas/Home/Index.vue';
import App from "./app.vue";
import Navbar from "../Components/Navbar.vue";

const Foo = { template: '<div>foo</div>' }
const Bar = { template: '<div>bar</div>' }

const routes = [
    { path: '/Reservation', component: Foo },
    { path: '/Home', component: Home }
];

const router = new VueRouter({
    routes // short for `routes: routes`
});

const NotFound = { template: '<p>Page not found</p>' }

//const routes = {
//    '/': Home,
//    '/about': 'About'
//}

Vue.component('my-navbar', Navbar);

Vue.component('my-component',
    {
        template: '<div>A custom component!</div>'
    });



const v = new Vue({
    router,
    data: {
        message: 'Hello Vue.js!',
        currentRoute: window.location.pathname
    },
//    computed: {
//        ViewComponent() {
//            const matchingView = routes[this.currentRoute];
//
//            console.log(this.currentRoute)
//            return matchingView
//                ? Home
//                : NotFound
//        }
//    },
//    render(h) { return h(this.ViewComponent) },
    methods: {
      goBack() {
          window.history.length > 1
              ? this.$router.go(-1)
              : this.$router.push('/');
      }  
    },
    components: { App }

}).$mount('#app')