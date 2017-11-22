

<template>
    <div>
        <button v-on:click="confirmReservation()">Confirm reservation</button>
    </div>
</template>

<<script>
export default {
        name: 'ConfirmReservation',
        data() {
            return {
            }
        },
        created: function () {
        },
        methods: {
            confirmReservation() {
                // Takiseer SuperPass
                axios.post("Reservation/Reservation/Confirm", {
                    movieId: 2,
                    cinemaId: 7,
                    seanceId: 1,
                    reservationId: 4,
                });
            }
        }
    }
</script>
