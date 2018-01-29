

<template>
    <section class="section">
        
        <h2 class="title is-2">Repertoire</h2>
        
        <repertoire-preview></repertoire-preview>   
    </section>
</template>

<script>
    import RepertoirePreview from 'Components/RepertoirePreview.vue';

    export default {
        name: 'RegistrationRepertoireStep',
        components: {
            RepertoirePreview
        },
        created: function () {
            this.getRepertoire();
        },
        data: function () {
            return {
                repertoire: [],
                selectedDate: new Date()
            }
        },
        methods: {
            previousDay: function() {
                this.selectedDate.setDate(this.selectedDate.getDate() - 1)
                this.getRepertoire();
            },
            nextDay: function() {
                this.selectedDate.setDate(this.selectedDate.getDate() + 1)
                this.getRepertoire();
            },
            getRepertoire: function() {
                axios.post("Repertoire/Repertoire/GetRepertoire", {cinemaId: 8, date: this.selectedDate})
                    .then((res) => {
                        this.repertoire = res.data;
                    }).catch((e) => {
                        console.error(e);
                    });
            },
            goToSeance: function(seanceId) {
                axios.post("Reservation/Reservation/GetResevationParams", {seanceId: seanceId})
                    .then((res) => {
                        console.log(res.data);
                        this.$router.push({ name: 'PickSeats', params: { 
                            movieId: res.data.movieId, 
                            cinemaId: res.data.cinemaId,
                            seanceId: res.data.id 
                            }
                        });
                    });
            }
        }
    }
</script>

<style lang="scss">

</style>
