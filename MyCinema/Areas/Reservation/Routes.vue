
<script>
    import PickMovie from './Views/PickMovie.vue';
    import PickCinema from './Views/PickCinema.vue';
    import PickSeance from './Views/PickSeance.vue';
    import PickSeats from './Views/PickSeats.vue';

    export default [
        { path: '/Reservation', component: PickMovie },
        { path: '/Reservation/:movieId', component: PickCinema },
        { path: '/Reservation/:movieId/:cinemaId', component: PickSeance },
        { path: '/Reservation/:movieId/:cinemaId/:seanceId', component: PickSeats },
    ]
</script>