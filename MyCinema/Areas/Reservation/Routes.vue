
<script>
    import PickMovie from './Views/PickMovie.vue';
    import PickCinema from './Views/PickCinema.vue';
    import PickSeance from './Views/PickSeance.vue';
    import PickSeats from './Views/PickSeats.vue';

    export default [
        { name: 'PickMovie', path: '/Reservation', component: PickMovie },
        { name: 'PickCinema', path: '/Reservation/:movieId', component: PickCinema },
        { name: 'PickSeance', path: '/Reservation/:movieId/:cinemaId', component: PickSeance },
        { name: 'PickSeats', path: '/Reservation/:movieId/:cinemaId/:seanceId', component: PickSeats },
    ]
</script>