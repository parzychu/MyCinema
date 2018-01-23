<template>
    <section class="section">
        <div class="columns">
            <div class="column is-2">

            </div>
            <div class="column is-8">
                <reservation-details-preview class="content" :source="reservationDetails"></reservation-details-preview>
            </div>

        </div>
        <div v-on:click="confirmReservation()" class="reservation-btn-next">
            <span>Potwierdź rezerwację</span>

            <i class="fa fa-arrow-circle-right level-left" aria-hidden="true"></i>
        </div>
    </section>
</template>

<script>
    import ReservationDetailsPreview from 'Components/ReservationDetailsPreview.vue';

    export default {
        name: 'ConfirmReservation',
        components: {
            ReservationDetailsPreview
        },
        data() {
            return {
                reservationDetails: {}
            }
        },
        created: function () {
            axios.post("Reservation/Reservation/ReservationDetails", {
                reservationId: this.$route.params.reservationId
            }).then((res) => this.reservationDetails = res.data);
        },
        methods: {
            confirmReservation() { 
                // Takiseer SuperPass 
                axios.post("Reservation/Reservation/Confirm", {reservationId: this.$route.params.reservationId});
            }
        }
    }
</script>

<style lang="scss">
    .reservation-details {
        display: flex;
        font-size: 22px;
        padding: 20px;

        .left-column {
            flex: 1 1 50%;
            text-align: right;

            >div {
                padding-right: 10px;
                border-bottom: 1px solid #f5f5f5;
            }
        }
        .right-column {
            flex: 1 1 50%;

            >div {
                padding-left: 10px;
                border-bottom: 1px solid #f5f5f5;
            }
        }
    }
</style>