
<template>
    <section class="section">
        <nav class="breadcrumb has-arrow-separator is-large" aria-label="breadcrumbs">
            <ul>
                <li><router-link :to="{name: 'PickMovie'}">Film</router-link></li>
                <li><router-link :to="{name: 'PickCinema'}">Kino</router-link></li>
                <li><router-link :to="{name: 'PickSeance'}">Data i godzina</router-link></li>
                <li class="is-active"><router-link :to="{name: 'PickSeats'}" aria-current="page"> Wybierz Miejsca</router-link></li>
            </ul>
        </nav>
        <div class="pick-cinema-screen">Ekran</div>
        
        <seats-picker @changed="onSeatsPickerChanged" :seats="seats"></seats-picker>
        
        <div v-on:click="reserveSeats()" class="reservation-btn-next">
            <span>Dalej</span>
            <i class="fa fa-arrow-circle-right level-left" aria-hidden="true"></i>
        </div>
    </section>
</template>

<script>
    import SeatsPicker from 'Components/SeatsPicker/SeatsPicker.vue';

    export default {
        name: 'PickSeats',
        components: {
            'seats-picker': SeatsPicker
        },
        data: function() {
            return {
                seats: [],
                pickedSeats: []
            }
        },
        created: function () {
            this.getSeats();
        },
        methods: {
            getSeats: function() {
                axios.post("Reservation/Reservation/GetSeats", {seanceId: this.$route.params.seanceId})
                .then((res) => {
                    this.seats = res.data;
                }).catch((e) => {
                    console.error(e);
                });
            },
            onSeatsPickerChanged: function(value) {
                this.pickedSeats = value;
            },
            reserveSeats: function() {
                var reservationInfo = {
                    seanceId: this.$route.params.seanceId,
                    seatIds: this.pickedSeats
                }

                axios.post("Reservation/Reservation/CreateReservation", reservationInfo)
                    .then((res => {
                        this.$router.push({ name: 'ConfirmReservation', params: { reservationId: res.data }});
                    }).bind(this));
            }
        }
    }
</script>

<style lang="scss">

    @import "Styles/Variables";

    .pick-cinema-screen {
        color: $my-color-gray-text;
        border: 1px solid $my-color-gray-text;
        padding: 2px 0;
        margin: 0 auto;
        width: 500px;
        text-align: center;
        margin-bottom: 50px;
    }
</style>