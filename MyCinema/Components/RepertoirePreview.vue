

<template>
    <div>
        <button v-on:click="previousDay()">&lt;</button>{{selectedDate}}<button v-on:click="nextDay()">></button>
        
        <h2 class="title is-2">Repertoire</h2>
        <div style="display: grid; grid-template-columns: repeat(3, 1fr);">
            <div v-for="(movie, index) in repertoire" :key="index" style="display: flex">
                <div>{{movie.title}}</div>
                <div v-for="(seance, index) in movie.seances" :key="index" v-on:click="goToSeance(seance.id)">
                    {{seance.id}} - {{seance.time}}
                    </div>
                </div>
            </div>
        </div>       
    </div>
</template>

<script>
    import CurrentlyPlayingSection from 'Components/CurrentlyPlayingSection/CurrentlyPlayingSection.vue';

    export default {
        name: 'RepertoirePreview',
        components: {
            CurrentlyPlayingSection
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
                axios.post("Reservation/Reservation/GetRepertoire", {cinemaId: 8, date: this.selectedDate})
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
