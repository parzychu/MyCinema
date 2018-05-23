

<template>
    <section class="section">
        
        <div class="price-list">
            <div><h2 class="title is-3">Cennik</h2> </div>
            <div>Pn,Wt,Czw</div>
            <div>Śr</div>
            <div>Pt,Sob,Nd,Św</div>           
            <div>Normalny</div>
            <div>23zł</div>
            <div>19zł</div>
            <div>26zł</div>
            <div>Ulgowy</div>
            <div>20zł</div>
            <div>17zł</div>
            <div>24zł</div>
        </div>
    </section>
</template>

<script>
    import CurrentlyPlayingSection from 'Components/CurrentlyPlayingSection/CurrentlyPlayingSection.vue';

    export default {
        name: 'PriceList',
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
            }
        }
    }
</script>

<style lang="scss">
    .price-list {
        display: grid;
        grid-template-columns: 200px 200px 200px 200px;
        grid-template-rows: 80px 80px 80px;
        font-size: 30px;
        justify-content: center;
        grid-gap: 1px 1px;

        & >div {
            background-color: white;
            margin: 1px;
            display: flex;
            align-items: center;
            justify-content: center;
        }
    }
</style>
