<template>
    <div class="show-keeps-component ilb">

        <button @click="showMyKeepsList(); getKeepsByUserId();" class="btn btn-primary custom-btn">My Keeps</button>

        <button @click="ShowAllKeeps" class="btn btn-primary custom-btn">Keeps</button>


    </div>

</template>

<script>
    import Vue from 'vue'
    export default {
        name: 'ShowKeeps',
        data() {
            return {



            }
        },
        mounted() {


            // this.$store.dispatch('getKeepsByUserId', this.user.id)
            // console.log(this.user.id)
        },

        methods: {
            ShowAllKeeps() {
                this.$store.dispatch('showAllKeeps')
            },
            showMyKeepsList() {
                this.$store.dispatch('showMyKeeps')
            },
            getKeepsByUserId() {
                this.$store.dispatch('getKeepsByUserId', this.user.id)
            }
        },
        computed: {
            user() {
                return this.$store.state.user
            }
            
        },
        components: {

        }
    }


</script>

<style scoped>
    .keeps-img {
        margin: auto;
    }

    .keep {
        border-radius: 5px;
        margin-top: 5%;
    }

    .keeps-img:hover {
        background: green;
    }

    .add-to-vault-button {
        background: black;
        color: white;
    }

    .keep-preview {
        font-weight: bold;
    }

    .icons {
        color: black;
        margin-right: 1rem;
    }
</style>