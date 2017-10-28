
console.log("webpack ok");

import Vue from "vue";
import VueRouter from "vue-router";
Vue.use(VueRouter);
import Home from '../Areas/Home/Index.vue';

import ReservationRoutes from '../Areas/Reservation/Routes.vue';
import App from "./app.vue";
import Navbar from "../Components/Navbar.vue";


const routes = [
    ...ReservationRoutes,
    { path: '/Home', component: Home }
];

const router = new VueRouter({
    routes
});

const NotFound = { template: '<p>Page not found</p>' }

Vue.component('my-navbar', Navbar);

Vue.component('my-component',
    {
        template: '<div>A custom component!</div>'
    });



const v = new Vue({
    router,
    data: {
        message: 'Hello Vue.js!'
    },
    methods: {
      goBack() {
          window.history.length > 1
              ? this.$router.go(-1)
              : this.$router.push('/');
      }  
    },
    components: { App }

}).$mount('#app')