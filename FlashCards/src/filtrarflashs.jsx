import { Input } from "@/components/ui/input"
import { Button } from "@/components/ui/button"

export default function FiltrarFlashs(props){

    function filtrar(){
        if(props.flashSearch.length > 0){
            fetch(`https://localhost:7158/findbynameflash?name=${props.flashSearch}`, {
                method: 'GET',
                headers: {
                    'Content-Type': 'application/json',
                }
            })
            .then(response => response.json())
            .then(data =>{
                props.setFlashs(data)
            })
        }
        else{
            props.atualizarFlashs()
        }
    }

    return(
        <>
            <div class="flex w-72">
                <div className="w-60">
                <Input type="text" value={props.flashSearch} placeholder="Digite o flash" onChange={(e) => props.setFlashSearch(e.target.value)}/>
                </div>
                <div className="ml-2">
                    <Button onClick={filtrar}>OK</Button>
                </div>
            </div>
        </>
    )
}