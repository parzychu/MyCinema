

<template>
    <div>
        Movie: {{reservationDetails.movieTitle}}
        Cinema: {{reservationDetails.cinema}}
        Date: {{reservationDetails.date}} {{reservationDetails.time}}
        <div v-for="seat in reservationDetails.seats">
            <div>{{seat.column}}</div>
            <div>{{seat.row}}</div>
        </div>
        <button v-on:click="confirmReservation()">Confirm reservation</button>
    </div>
</template>

<<script>
export default {
        name: 'ConfirmReservation',
        data() {
            return {
                reservationDetails: {}
            }
        },
        created: function () {
            axios.post("Reservation/Reservation/ReservationDetails", {reservationId: this.$route.params.reservationId})
                .then((res) => this.reservationDetails = res.data);
        },
        methods: {
            confirmReservation() {
                // Takiseer SuperPass
                axios.post("Reservation/Reservation/Confirm", {reservationId: this.$route.params.reservationId});
            }
        }
    }
</script>
