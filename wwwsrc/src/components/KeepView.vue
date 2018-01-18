<template>
    <!-- <div v-if="activekeep.name">
        <div class="modal fade" id="keep-view" tabindex="-1" role="dialog" aria-labelledby="keep-view">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-body">
                        <div v-for="keep in activeKeep">

                            <img :src="keep.imageURL" alt="">
                            <p>{{keep.name}}</p>
                            <p>{{keep.description}}</p>
                        </div>


                        <button type="button" class="btn btn-default" data-dismiss="modal">Cancel</button>
                    </div>
                </div>
            </div>
        </div>

    </div> -->

</template>

<script>
    export default {
        name: '',
        data() {
            return {

            }
        },
        mounted() {

        },

        methods: {

        },
        computed: {
            activeKeep() {
                return this.$store.state.activeKeep
            }

        },
        components: {

        }
    }

</script>

<style>
</style>