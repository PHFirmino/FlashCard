import EditarCard from "./editarcard"
import ExcluirCard from "./excluircard"

export default function CarregarCards(props){

    return (
        <>
            <div class="flex flex-wrap m-5 pl-4">
                {
                    props.cards.map((card) => {
                        return(
                            <div class="flashcard-container" key={card.id}>
                                <div class="flashcard">
                                    <div class="question shadow-lg">
                                <div class="content">
                                    <p class="h-44">{card.pergunta}</p>
                                </div>
                                </div>
                                    <div class="answer shadow-lg">
                                        <div class="content">
                                            <p class="h-44">{card.resposta}</p>
                                            <div class="flex justify-between">
                                                <div class="w-1/2">
                                                    <ExcluirCard card={card} atualizarCards={props.atualizarCards}/>
                                                </div>
                                                <div class="w-1/2">
                                                    <EditarCard card={card} atualizarCards={props.atualizarCards}/>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        )
                    })
                }                        
            </div>
        </>
    )

}