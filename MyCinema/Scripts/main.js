
console.log("webpack ok");

import Vue from "vue";
import VueRouter from "vue-router";
Vue.use(VueRouter);

import Buefy from 'buefy';
Vue.use(Buefy);
// import 'buefy/lib/buefy.css';
// import Style from '../Styles/Main.scss';

import Auth from "./auth.js";
import Home from '../Areas/Home/Index.vue';
import ReservationRoutes from '../Areas/Reservation/Routes.vue';
import App from "./app.vue";
import Navbar from "../Components/Navbar.vue";
import MoviePreviewItem from 'Components/MoviePreview/MoviePreview.vue';
import Repertoire from '../Areas/Repertoire/Index.vue';
import PriceList from '../Areas/PriceList/PriceList.vue';
import LogInPage from '../Areas/Reservation/Views/LogInPage.vue';
import Registration from '../Areas/Auth/Views/Registration.vue';
import UserRoutes from '../Areas/User/Routes.vue';


const routes = [
    ...ReservationRoutes,
    ...UserRoutes,
    { path: '/Repertoire', component: Repertoire },
    { path: '/Home', component: Home },
    { path: '/PriceList', component: PriceList },
    { path: '/Login', component: LogInPage },
    { path: '/Registration', component: Registration}
];

let router = new VueRouter({
    routes
});

Auth.checkAuth();

router.beforeEach((to, from, next) => {
    console.log(to, from)

    if (to.meta.requiresAuth) {
        console.log(Auth)

        if (!Auth.user.authenticated)
            next(to.meta.redirect);
    }

    next();
});

const NotFound = { template: '<p>Page not found</p>' }

Vue.component('my-navbar', Navbar);

Vue.component('movie-previev-item', MoviePreviewItem);

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