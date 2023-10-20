'use client'
import FormDogs from "@/components/form";
import axios from "axios";
import { useState } from "react"


export default function Home() {

  const [useForm, setUseForm] = useState(false);


  return (
    <main className="flex min-h-screen flex-col items-center justify-center p-24">
      { useForm ?
        <div className="mx-32 justify-center content-center">
          <FormDogs></FormDogs>
        </div> 

        : 

        <div onClick={e => setUseForm(true)} className="mx-32 justify-center content-center">
          <h1 className="text-7xl">
            Eduardo, vamos deixar seus cães arrumados, felizes e cheirosos?
          </h1>

          <span className="min-w-screen text-right info">clique para orçar o banho deles</span>
        </div>
      }
      
    </main>
  )
}
