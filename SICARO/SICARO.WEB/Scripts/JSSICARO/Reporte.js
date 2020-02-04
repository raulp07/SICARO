﻿$(document).ready(function () {


    var Reportes = new Vue({
        el: "#reporte",
        data: {
            grupos : [
                    { "Grupo": 1, "NroRomano": "I", "Descripcion": "DEL ÁREA DE ALMACENAMIENTO DE MATERIA PRIMA E INSUMOS" },
                    { "Grupo": 2, "NroRomano": "II", "Descripcion": "DEL ÁREA DE PROCESO" },
                    { "Grupo": 3, "NroRomano": "III", "Descripcion": "DEL ÁREA DE ENVASADO DEL PRODUCTO FINAL" },
                    { "Grupo": 4, "NroRomano": "IV", "Descripcion": "DEL ÁREA DE ALMACENAMIENTO DEL PRODUCTO FINAL" },
                    { "Grupo": 5, "NroRomano": "V", "Descripcion": "DE OTROS ALMACENES" },
                    { "Grupo": 6, "NroRomano": "VI", "Descripcion": "DE LOS VESTUARIOS Y SERVICIOS HIGIÉNICOS" },
                    { "Grupo": 7, "NroRomano": "VII", "Descripcion": "DE LAS CONDICIONES SANITARIAS GENERALES DEL ESTABLECIMIENTO" },
                    { "Grupo": 8, "NroRomano": "VIII", "Descripcion": "DE LOS REQUISITOS PREVIOS AL PLAN HACCP" },
            ],
            ListaProcedimiento : [

                    { "Grupo": 1, "orden": 1.01, "AspectoEvaluar": "El almacén es de uso exclusivo, apropiado para mantener la calidad sanitaria e inocuidad de los alimentos y se encuentra libre de materiales, productos o sustancias que puedan contaminar el producto almacenado. Las materias primas y los productos terminados se almacenan en ambientes separados. Art. 70 del D.S. N° 007-98-SA. Art. 9 de la R.M. N° 449-2006/MINSA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 1, "orden": 1.02, "AspectoEvaluar": "Las instalaciones (pisos, paredes, extructuras auxiliares) se encuentran limpios. Se toman las precauciones necesarias para impedir que el alimento sea contaminado cuando se realiza la limpieza y desinfección. Los implementos de limpieza son de uso exclusivo del área. Art. 56 del D.S. N° 007-98-SA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 1, "orden": 1.03, "AspectoEvaluar": "La estructura y acabado son construidos con materiales impermeables y resistentes a la acción de roedores. Art. 33, del D.S. 007-98-SA. Art. 9 de la R.M. N° 449-2006/MINSA.", "SI": "", "NO": "X", "OBSERVACION": "Nada" },
                    { "Grupo": 1, "orden": 1.04, "AspectoEvaluar": "La intensidad, calidad y distribución  de la iluminación natural o artificial (en caso necesario), es adecuada al tipo de trabajo, evita que se genere sombras, reflejo o encandilamiento y considera los niveles mínimos de iluminación siguientes: 540 LUX en zonas para examen detallado del producto220 LUX en las salas de producción110 LUX en otras zonas.Art. 34 del D.S. N° 007-98-SA. Art. 9 de la R.M. N° 449-2006/MINSA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 1, "orden": 1.05, "AspectoEvaluar": "La ventilación es adecuada para evitar el calor excesivo, asi como, la condensación de vapor de agua, y permitir la eliminación del aire contaminado. Las aberturas de ventilación están provistas de rejillas u otras protecciones de material anticorrosivo, facilmente desmontables para su limpieza. Art. 35 del D.S. N° 007-98-SA. Art. 9 de la R.M. N° 449-2006/MINSA.", "SI": "", "NO": "", "OBSERVACION": "Nada" },
                    { "Grupo": 1, "orden": 1.06, "AspectoEvaluar": "Las aberturas que comunican con el exterior (ventanas, puertas, tragaluces, drenajes, ductos de ventilación) están construidas de manera que impiden la acumulación de suciedad, son fáciles de limpiar y están protegidas (con mallas, flejes en bordes de puertas, tapas metálicas en sumideros, trampas en drenajes), para evitar el acceso de insectos u otros animales . Art. 33.e, 57 de D. S. 007-98-SA. Art. 9 de la R.M. N° 449-2006/MINSA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 1, "orden": 1.07, "AspectoEvaluar": "Los residuos sólidos están contenidos en recipientes de plástico o metálicos adecuadamente cubiertos o tapados y diseñados de tal manera que permitan su fácil y completa limpieza. Art. 38, 43 del D.S. N° 007-98-SA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 1, "orden": 1.08, "AspectoEvaluar": "Se identifica la fecha de ingreso de las materias primas e insumos y los registros (kardex) evidencian la adecuada rotación  en base al principio PEPS (lo primero que entra es lo primero que sale). Art. 60 del D.S. N° 007-98-SA. Art. 10.g, de la R.M. N° 449-2006/MINSA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 1, "orden": 1.09, "AspectoEvaluar": "Los productos almacenados se encuentran identificados y presentan fecha de vencimiento y registro sanitario vigente. Los aditivos y coadyuvantes están permitidos por el Codex Alimentarius y la legislación vigente.  Art. 62, 63, 102, 103, 116 del D.S. N° 007-98-SA. Art. 10.d de la R.M. N° 449-2006/MINSA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 1, "orden": 1.10, "AspectoEvaluar": "Los productos no perecibles (organizados y rotulados) son almacenados  en tarimas (parihuelas) o estántes, cuyo nivel inferior está a no menos de 0.20 metros del piso, el nivel superior a 0.60 metros o más del techo, y el espacio libre libre entre filas  de rumas, y entre estas y la pared es de 0.50 metros cuando menos. Art. 72 del D.S. N° 007-98-SA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 1, "orden": 1.11, "AspectoEvaluar": "Los productos perecibles se almacenan en cámaras de Refrigeración (   ) o congelación (   ), dotadas de dispositivos de medición y registro de temperatura en buenas condiciones de conservación y funcionamiento,  colocados en lugar visible. En la misma cámara no se almacena simultáneamente alimentos de distinta naturaleza que puedan provocar contaminación cruzada, salvo que estén envasados, acondicionados y cerrados debidamente. Art. 39, 45, 71, del D.S. N° 007-98-SA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 1, "orden": 1.12, "AspectoEvaluar": "Los productos almacenados en cámaras de enfriamiento (organizados y rotulados) son estibados en estántes, pilas o rumas que guardan distancias mínimas de 0.10 metros respecto del piso; 0.15 metros respecto de las paredes, y  0.50 metros respecto del techo.El espesor de las rumas permite un adecuado enfriamiento del producto.Los pasillos o espacios libres entre estántes o rumas permiten la inspección de las cargas.Art. 73 del D.S. N° 007-98-SA.", "SI": "", "NO": "", "OBSERVACION": "" },

                    { "Grupo": 2, "orden": 2.01, "AspectoEvaluar": "La distribución del ambiente permite el flujo de operaciones, desplazamiento de personal, materiales y equipos, de manera ordenada y separada de otros ambientes y no se comunica directamente con los servicios higiénicos, para evitar la contaminación cruzada. Art. 36, 44 del D.S. N° 007-98-SA. Art. 9 de la R.M. N° 449-2006/MINSA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 2, "orden": 2.02, "AspectoEvaluar": "Los ambientes se encuentran libres de productos, artículos, implementos o materiales extraños o ajenos a los que se elaboran. Art. 48 del D.S. N° 007-98-SA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 2, "orden": 2.03, "AspectoEvaluar": "Las instalaciones (pisos, paredes, extructuras auxiliares) se encuentran limpias. Se toman las precauciones necesarias para impedir que el alimento sea contaminado cuando se realiza la limpieza y desinfección. Los implementos de limpieza son de uso exclusivo del área. Art. 56 del D.S. N° 007-98-SA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 2, "orden": 2.04, "AspectoEvaluar": "Las uniones entre las paredes y el piso son a media caña (curvo/cóncavo), lo que facilita la limpieza de los ambientes y evita la acumulación de elementos extraños. Literal a del Art. 33 del D.S. 007-98-SA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 2, "orden": 2.05, "AspectoEvaluar": "Los pisos tienen declive hacia canaletas o sumideros convenientemente dispuestos para facilitar el lavado y el escurrimiento de líquidos. Literal b del Art. 33 del D.S. 007-98-SA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 2, "orden": 2.06, "AspectoEvaluar": "Las paredes son de material impermeable, de superficie lisa, sin grietas y están recubiertas con pintura lavable de color claro. Literal c del Art. 33 del D.S. 007-98-SA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 2, "orden": 2.07, "AspectoEvaluar": "El techo tiene acabado liso e impermeable, que facilita la limpieza y se encuentra libre de condensaciónes y mohos. Literal d del Art. 33 del D.S. 007-98-SA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 2, "orden": 2.08, "AspectoEvaluar": "Las aberturas que comunican con el exterior (ventanas, puertas, tragaluces, drenajes, ductos de ventilación) están construidas de manera que impiden la acumulación de suciedad, son fáciles de limpiar y están protegidas (con mallas, flejes en bordes de puertas, tapas metálicas en sumideros, trampas en drenajes) para evitar el acceso de insectos u otros animales . Literal e del Art. 33 y 57 del D.S. 007-98-SA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 2, "orden": 2.09, "AspectoEvaluar": "La intensidad, calidad y distribución  de la iluminación natural o artificial (en caso necesario), es adecuada al tipo de trabajo, evita que se genere sombras, reflejo o encandilamiento y considera los niveles mínimos de iluminación siguientes:  540 LUX en zonas para examen detallado del producto 220 LUX en las salas de producción 110 LUX en otras zonas. Art. 34 del D.S. N° 007-98-SA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 2, "orden": 2.10, "AspectoEvaluar": "La ventilación es adecuada para evitar el calor excesivo, asi como, la condensación de vapor de agua y permitir la eliminación del aire contaminado. Las aberturas de ventilación están provistas de rejillas u otras protecciones de material anticorrosivo, facilmente desmontables para su limpieza.Art. 35 del D.S. N° 007-98-SA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 2, "orden": 2.11, "AspectoEvaluar": "Los residuos sólidos están contenidos en recipientes de plástico o metálicos adecuadamente cubiertos o tapados y diseñados de tal manera que permitan su fácil y completa limpieza. Art. 38, 43 del D.S. N° 007-98-SA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 2, "orden": 2.12, "AspectoEvaluar": "Los alimentos y bebidas, asi como, la materia prima se depositan en tarimas (parihuelas) o estántes cuyo nivel inferior está a no menos de 0.20 metros del piso, el nivel superior a 0.60 metros o más del techo y el espacio libre libre entre filas  de rumas, y entre estas y la pared es de 0.50 metros cuando menos. Art. 72 del D.S. N° 007-98-SA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 2, "orden": 2.13, "AspectoEvaluar": "Los equipos (fijos o móviles) y utensilios están diseñados de manera que permiten su fácil y completa limpieza y desinfección. Están fabricados de materiales que no producen ni emiten sustancias tóxicas ni impregnan olores o sabores desagradables; son no absorbentes,  resistentes a la corrosión y capaces de soportar repetidas operaciones de limpieza y desinfección. Sus superficies son lisas y están exentas de orificios y grietas. Art. 37, 38 del D.S. N° 007-98-SA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 2, "orden": 2.14, "AspectoEvaluar": "Los operarios se lavan y desinfectan las manos, antes de iniciar el trabajo, después de utilizar los servicios higiénicos y manipular material sucio o contaminado, y todas las veces que sea necesario. Se colocan avisos que indiquen la obligación de lavarse las manos. Existe un control adecuado que garantiza el cumplimiento de este requisito. Art. 55 del D.S. N° 007-98-SA. ", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 2, "orden": 2.15, "AspectoEvaluar": "Los operarios se encuentran aseados; con manos limpias,  sin cortes, ulceraciones ni otras afecciones a la piel, sin sortijas, pulseras o cualquier otro adorno; uñas cortas y sin esmalte. El uniforme es de color claro, en buen estado de aseo y conservación, exclusivo para la labor que desempeña (incluyendo personal de limpieza, mantenimiento y servicio de terceros). La indumentaria consta de: gorra, zapatos, overol o chaqueta y pantalón. Cuando las operaciones de procesamiento y envasado del producto se realicen en forma manual, sin posterior tratamiento que garantice la eliminación de cualquier posible contaminación proveniente del manipulador, el personal que interviene en éstas debe estar dotado de mascarilla y guantes. El personal que realiza lavado de equipo y envases cuenta, además, con botas y delantal impermeable. Art. 50, 51 del D.S. N° 007-98-SA. ", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 2, "orden": 2.16, "AspectoEvaluar": "Se observó durante la inspección la aplicación de Buenas Prácticas de Manipulación por parte del personal. Art. 49, 50, 52 del D.S. N° 007-98-SA.", "SI": "", "NO": "", "OBSERVACION": "" },

                    { "Grupo": 3, "orden": 3.01, "AspectoEvaluar": "La distribución del ambiente permite el flujo de operaciones, desplazamiento de personal, materiales y equipos, de manera ordenada y separada de otros ambientes y no se comunica directamente con los servicios higiénicos, para evitar la contaminación cruzada. Art. 36, 44 del D.S. N° 007-98-SA; Art. 9 de la R.M. N° 449-2006/MINSA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 3, "orden": 3.02, "AspectoEvaluar": "Los ambientes se encuentran libres de productos, artículos, implementos o materiales extraños o ajenos a los que se elaboran. Art. 48 del D.S. N° 007-98-SA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 3, "orden": 3.03, "AspectoEvaluar": "Las instalaciones (pisos, paredes, extructuras auxiliares) se encuentran en buen estado limpieza. Se toman las precauciones necesarias para impedir que el alimento sea contaminado cuando se realiza la limpieza y desinfección. Los implementos de limpieza son de uso exclusivo del área. Art. 56 del D.S. N° 007-98-SA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 3, "orden": 3.04, "AspectoEvaluar": "Las uniones entre las paredes y el piso son a media caña (curvo/cóncavo), lo que facilita la limpieza de los ambientes y evita la acumulación de elementos extraños. Art. 33.a del D.S. N° 007-98-SA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 3, "orden": 3.05, "AspectoEvaluar": "Los pisos tienen declive hacia canaletas o sumideros convenientemente dispuestos para facilitar el lavado y el escurrimiento de líquidos. Art. 33.b del D.S. N° 007-98-SA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 3, "orden": 3.06, "AspectoEvaluar": "Las paredes son de material impermeable, de superficie lisa, sin grietas y están recubiertas con pintura lavable de color claro. Art. 33.c del D.S. N° 007-98-SA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 3, "orden": 3.07, "AspectoEvaluar": "El techo tiene acabado liso e impermeable que facilita la limpieza, se encuentra libre de condensaciónes y mohos. Art. 33.d del D.S. N° 007-98-SA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 3, "orden": 3.08, "AspectoEvaluar": "Las aberturas que comunican con el exterior (ventanas, puertas, tragaluces, drenajes, ductos de ventilación) están construidas de manera que impiden la acumulación de suciedad, son fáciles de limpiar y están protegidas (con mallas, flejes en bordes de puertas, tapas metálicas en sumideros, trampas en drenajes), para evitar el acceso de insectos u otros animales. Art. 33.e, 57 del D.S. N° 007-98-SA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 3, "orden": 3.09, "AspectoEvaluar": "La intensidad, calidad y distribución  de la iluminación natural o artificial (en caso necesario), es adecuada al tipo de trabajo, evita que se genere sombras, reflejo o encandilamiento y considera los niveles mínimos de iluminación siguientes: 540 LUX en zonas para examen detallado del producto 220 LUX en las salas de producción 110 LUX en otras zonas. Art. 34 del D.S. N° 007-98-SA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 3, "orden": 3.10, "AspectoEvaluar": "La ventilación es adecuada para evitar el calor excesivo así como la condensación de vapor de agua y permitir la eliminación del aire contaminado. Las aberturas de ventilación están provistas de rejillas u otras protecciones de material anticorrosivo, fácilmente desmontables para su limpieza. Art. 35 del D.S. N° 007-98-SA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 3, "orden": 3.11, "AspectoEvaluar": "Los residuos sólidos están contenidos en recipientes de plástico o metálicos adecuadamente cubiertos o tapados y diseñados de tal manera que permitan su fácil y completa limpieza. Art. 38, 43 del D.S. N° 007-98-SA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 3, "orden": 3.12, "AspectoEvaluar": "Los alimentos y bebidas, así como, la materia prima se depositan en tarimas (parihuelas) o estántes cuyo nivel inferior está a no menos de 0.20 metros del piso, el nivel superior a 0.60 metros o más del techo y el espacio libre entre filas  de rumas y entre estas y la pared es de 0.50 metros cuando menos.  (Art. 72 del D.S. N° 007-98-SA.)", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 3, "orden": 3.13, "AspectoEvaluar": "Los equipos (fijos o móviles) y utensilios están diseñados de manera que permiten su fácil y completa limpieza y desinfección. Están fabricados de materiales que no producen ni emiten sustancias tóxicas ni impregnan de olores o sabores desagradables; son no absorbentes;  resistentes a la corrosión y capaces de soportar repetidas operaciones de limpieza y desinfección. Sus superficies son lisas y están exentas de orificios y grietas. Art. 37, 38 del D.S. N° 007-98-SA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 3, "orden": 3.14, "AspectoEvaluar": "Durante la etapa de envasado se aplican controles que aseguren la hermeticidad de los envases de manera que el producto mantenga la calidad sanitaria y composición del producto durante toda su vida útil. Art. 118 del D.S. N° 007-98-SA, literal e del Art. 10 de la R.M. N° 449-2006-MINSA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 3, "orden": 3.15, "AspectoEvaluar": "La información en el rotulado del producto final se sujeta a lo dispuesto en la reglamentación sanitaria vigente u otras normas aplicables al producto. Art. 116, 117 del D.S. N° 007-98-SA. Art. 14 de la R.M. N° 449-2006/MINSA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 3, "orden": 3.16, "AspectoEvaluar": "Los operarios se lavan y desinfectan las manos, antes de iniciar el trabajo, después de utilizar los servicios higiénicos y manipular material sucio o contaminado, así como, todas las veces que sea necesario. Se colocan avisos que indiquen la obligación de lavarse las manos. Existe un control adecuado que garantiza el cumplimiento de este requisito. Art. 55 del D.S. N° 007-98-SA. ", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 3, "orden": 3.17, "AspectoEvaluar": "Los operarios se encuentran aseados; con manos limpias,  sin cortes, ulceraciones ni otras afecciones a la piel, sin sortijas, pulseras o cualquier otro adorno; uñas cortas y sin esmalte. El uniforme es de color claro, en buen estado de aseo y conservación, exclusivo para la labor que desempeña (incluyendo personal de limpieza, mantenimiento y servicio de terceros). La indumentaria consta de: gorra, zapatos, overol o chaqueta y pantalón. Cuando las operaciones de procesamiento y envasado del producto se realicen en forma manual, sin posterior tratamiento que garantice la eliminación de cualquier posible contaminación proveniente del manipulador, el personal que interviene en éstas debe estar dotado de mascarilla y guantes. El personal que realiza lavado de equipo y envases cuenta, además, con botas y delantal impermeable. Art. 50, 51 del D.S. N° 007-98-SA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 3, "orden": 3.18, "AspectoEvaluar": "Se observó durante la inspección la aplicación de Buenas Prácticas de Manipulación por parte del personal. Art. 49, 50, 52 del D.S. N° 007-98-SA.", "SI": "", "NO": "", "OBSERVACION": "" },

                    { "Grupo": 4, "orden": 4.01, "AspectoEvaluar": "El almacén es de uso exclusivo, apropiado para mantener la calidad sanitaria e inocuidad de los alimentos y se encuentra libre de materiales, productos o sustancias que puedan contaminar el producto almacenado. Las materias primas y los productos terminados se almacenarán en ambientes separados. Art. 70 del D.S. N° 007-98-SA. Art. 9 de la R.M. N° 449-2006/MINSA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 4, "orden": 4.02, "AspectoEvaluar": "Las instalaciones (pisos, paredes, extructuras auxiliares) se encuentran en buen estado limpieza.Se toman las precauciones necesarias para impedir que el alimento sea contaminado cuando se realiza la limpieza y desinfección.Los implementos de limpieza son de uso exclusivo del área.Art. 56 del D.S. N° 007-98-SA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 4, "orden": 4.03, "AspectoEvaluar": "La estructura y acabado son construidos con materiales impermeables y resistentes a la acción de roedores. Art. 33, del D.S. 007-98-SA. Art. 9 de la R.M. N° 449-2006/MINSA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 4, "orden": 4.04, "AspectoEvaluar": "La intensidad, calidad y distribución  de la iluminación natural o artificial (en caso necesario), es adecuada al tipo de trabajo, evita que se genere sombras, reflejo o encandilamiento y considera los niveles mínimos de iluminación siguientes: 540 LUX en zonas para examen detallado del producto 220 LUX en las salas de producción 110 LUX en otras zonas. Art. 34 del D.S. N° 007-98-SA. Art. 9 de la R.M. N° 449-2006/MINSA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 4, "orden": 4.05, "AspectoEvaluar": "La ventilación es adecuada para evitar el calor excesivo, asi como, la condensación de vapor de agua y permitir la eliminación del aire contaminado. Las aberturas de ventilación están provistas de rejillas u otras protecciones de material anticorrosivo, fácilmente desmontables para su limpieza. Art. 35 del D.S. N° 007-98-SA. Art. 9 de la R.M. N° 449-2006/MINSA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 4, "orden": 4.06, "AspectoEvaluar": "Las aberturas que comunican con el exterior (ventanas, puertas, tragaluces, drenajes, ductos de ventilación) están construidas de manera que impiden la acumulación de suciedad, son fáciles de limpiar y están protegidas (con mallas, flejes en bordes de puertas, tapas metálicas en sumideros, trampas en drenajes), para evitar el acceso de insectos u otros animales. Art. 33.e, 57 de D. S. 007-98-SA. Art. 9 de la R.M. N° 449-2006/MINSA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 4, "orden": 4.07, "AspectoEvaluar": "Los residuos sólidos están contenidos en recipientes de plástico o metálicos adecuadamente cubiertos o tapados y diseñados de tal manera que permitan su fácil y completa limpieza. Art. 38, 43 del D.S. N° 007-98-SA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 4, "orden": 4.08, "AspectoEvaluar": "Los productos no perecibles (organizados y rotulados), son almacenados  en tarimas (parihuelas) o estántes, cuyo nivel inferior está a no menos de 0.20 metros del piso, el nivel superior a 0.60 metros o más del techo y el espacio libre libre entre filas  de rumas y entre estas y la pared es de 0.50 metros cuando menos. Art. 72 del D.S. N° 007-98-SA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 4, "orden": 4.09, "AspectoEvaluar": "El producto final perecible, se almacena en cámaras de Refrigeración (   ) o congelación (   ), dotadas de dispositivos de medición y registro de temperatura en buenas condiciones de conservación y funcionamiento y colocados en lugar visible. En la misma cámara de enfriamiento no se almacena simultáneamente alimentos de distinta naturaleza que puedan provocar la contaminación cruzada de los productos, salvo que estén envasados, acondicionados y cerrados debidamente. Art. 39, 45, 71, del D.S. N° 007-98-SA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 4, "orden": 4.10, "AspectoEvaluar": "El producto final almacenado en cámaras de enfriamiento es estibado en estántes, pilas o rumas, que guardan distancias mínimas de 0.10 metros respecto del piso; 0.15 metros respecto de las paredes y  0.50 metros respecto del techo.El espesor de las rumas permite un adecuado enfriamiento del producto.Los pasillos o espacios libres entre estántes o rumas permiten la inspección de las cargas.Art. 73 del D.S. N° 007-98-SA.", "SI": "", "NO": "", "OBSERVACION": "" },

                    { "Grupo": 5, "orden": 5.01, "AspectoEvaluar": "Las instalaciones (pisos, paredes, extructuras auxiliares) se encuentran en buen estado limpieza. Se toman las precauciones necesarias para impedir que el alimento sea contaminado cuando se realiza la limpieza y desinfección. Los implementos de limpieza son de uso exclusivo del área. Art. 56 del D.S. N° 007-98-SA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 5, "orden": 5.02, "AspectoEvaluar": "La estructura y acabado son construidos con materiales impermeables y resistentes a la acción de roedores. Art. 33, del D.S. 007-98-SA. Art. 9 de la R.M. N° 449-2006/MINSA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 5, "orden": 5.03, "AspectoEvaluar": "La intensidad, calidad y distribución  de la iluminación natural o artificial (en caso necesario), es adecuada al tipo de trabajo, evita que se genere sombras, reflejo o encandilamiento y considera los niveles mínimos de iluminación siguientes: 540 LUX en zonas para examen detallado del producto 220 LUX en las salas de producción 110 LUX en otras zonas. Art. 34 del D.S. N° 007-98-SA. Art. 9 de la R.M. N° 449-2006/MINSA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 5, "orden": 5.04, "AspectoEvaluar": "La ventilación es adecuada para evitar el calor excesivo, así como, la condensación de vapor de agua y permitir la eliminación del aire contaminado. Las aberturas de ventilación están provistas de rejillas u otras protecciones de material anticorrosivo, fácilmente desmontables para su limpieza. Art. 35 del D.S. N° 007-98-SA. Art. 9 de la R.M. N° 449-2006/MINSA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 5, "orden": 5.05, "AspectoEvaluar": "Los plaguicidas, productos de limpieza y desinfección y otras sustancias tóxicas, se almacenan en sus envases originales, protegidos e identificados, en un ambiente separado de las áreas donde se manipulan y almacenan alimentos. Art. 48, 70 del D.S. N° 007-98-SA. Art. 9 de la R.M. N° 449-2006/MINSA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 5, "orden": 5.06, "AspectoEvaluar": "El almacenamiento de los materiales de empaque y embalaje se realiza en ambientes apropiados, los mismos que se encuentran en buen estado de mantenimiento, limpieza, ventilación e iluminación. Art. 34, 35, 70 del D.S. N° 007-98-SA.  Art. 9 de la R.M. N° 449-2006/MINSA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 5, "orden": 5.07, "AspectoEvaluar": "Los materiales de empaque y embalaje son estibados en tarimas (parihuelas) o estantes cuyo nivel inferior está a no menos de 0.20 metros del piso, el nivel superior a 0.60 metros o más del techo y el espacio libre entre filas  de rumas y entre estas y la pared es de 0.50 metros cuando menos. Art. 72 del D.S. N° 007-98-SA.  Art. 9 de la R.M. N° 449-2006/MINSA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 5, "orden": 5.08, "AspectoEvaluar": "Las aberturas que comunican con el exterior (ventanas, puertas, tragaluces, drenajes, ductos de ventilación) están construidas de manera que impiden la acumulación de suciedad, son fáciles de limpiar y están protegidas (con mallas, flejes en bordes de puertas, tapas metálicas en sumideros, trampas en drenajes), para evitar el acceso de insectos u otros animales .Art. 33.e, 57 de D. S. 007-98-SA. Art. 9 de la R.M. N° 449-2006/MINSA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 5, "orden": 5.09, "AspectoEvaluar": "Los residuos sólidos están contenidos en recipientes de plástico o metálicos adecuadamente cubiertos o tapados y diseñados de tal manera que permitan su fácil y completa limpieza. Art. 38, 43 del D.S. N° 007-98-SA.", "SI": "", "NO": "", "OBSERVACION": "" },

                    { "Grupo": 6, "orden": 6.01, "AspectoEvaluar": "Los vestuarios y duchas están construidos de material impermeable, resistente a la acción de los roedores . Se facilita al personal, espacios adecuados  para el cambio de vestimenta, y diponen de facilidades para depositar la ropa de trabajo y de diario de manera que unas y otras no entren en contacto. Art. 33 y 53 del D.S. N° 007-98-SA. Art. 9 de la R.M. N° 449-2006/MINSA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 6, "orden": 6.02, "AspectoEvaluar": "Los servicios higiénicos están construidos de material impermeable, resistente a la acción de los roedores y se encuentran alejados de las salas de fabricación a fin de evitar la contaminación cruzada. Se mantienen en buen estado de conservación e higiene. Art. 33, 36 y 54 del D.S. N° 007-98-SA. Art. 9 de la R.M. N° 449-2006/MINSA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 6, "orden": 6.03, "AspectoEvaluar": "La intensidad, calidad y distribución  de la iluminación natural o artificial (en caso necesario), es adecuada al tipo de trabajo, evita que se genere sombras, reflejo o encandilamiento y considera los niveles mínimos de iluminación siguientes: 540 LUX en zonas para examen detallado del producto 220 LUX en las salas de producción 110 LUX en otras zonas. Art. 34 del D.S. N° 007-98-SA. Art. 9 de la R.M. N° 449-2006/MINSA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 6, "orden": 6.04, "AspectoEvaluar": "La ventiación es adecuada para evitar el calor excesivo asi como la condensación de vapor de agua y permitir la eliminación del aire contaminado. Las aberturas de ventiación están provistas de rejillas u otras protecciones de material anticorrosivo, facilmente desmontables para su limpieza. Art. 35 del D.S. N° 007-98-SA. Art. 9 de la R.M. N° 449-2006/MINSA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 6, "orden": 6.05, "AspectoEvaluar": "Los inodoros, urinarios, lavatorios, duchas se encuentran instalados en un sistema que asegura la eliminación higiénica de las aguas residuales y su material permite la fácil limpieza y desinfección. Art. 38, 42, 54 del D.S. N° 007-98-SA. Art. 9 de la R.M. N° 449-2006/MINSA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 6, "orden": 6.06, "AspectoEvaluar": "Es adecuada la relación de aparatos sanitarios con respecto al número de personal y género (hombres y mujeres): De 01a09 personas:01 inodoro,02 lavatorios,01 ducha,01 urinario. (  )    De10a24 personas:02 inodoros,04 lavatorios,02 duchas,01urinario ( ) De25a49 personas:03inodoros,05lavatorios,03duchas,02urinarios. (  )    De50a100personas:05inodoros,10lavatorios,06duchas,04 urinarios(  )  Más de 100 personas: 01 aparato adicional por cada 30 personas. (  )   Art. 54 del D.S. N° 007-98-SA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 6, "orden": 6.07, "AspectoEvaluar": "Los residuos sólidos están contenidos en recipientes de plástico o metálicos adecuadamente cubiertos o tapados y diseñados de tal manera que permitan su fácil y completa limpieza.Art. 38, 43 del D.S. N° 007-98-SA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 6, "orden": 6.08, "AspectoEvaluar": "El gabinete de higienización de manos, de los servicios higiénicos cuenta con avisos que indican la obligación de lavarse la manos, jabón, desinfectante y medios de secado (toalla desechable, secador automático). En caso de usar toalla desechable, existe un tacho de residuos con tapa activada a pedal. Art. 55 del D.S. N° 007-98-SA. ", "SI": "", "NO": "", "OBSERVACION": "" },

                    { "Grupo": 7, "orden": 7.01, "AspectoEvaluar": "El establecimiento cumple con la condición de estar ubicado a no menos de 150 m. de algún establecimiento o actividad que represente riesgo de contaminación. La municipalidad verifica el cumplimiento de lo dispuesto mediante el otorgamiento de la licencia municipal. Art. 30 del D.S. N° 007-98-SA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 7, "orden": 7.02, "AspectoEvaluar": "Las vías de acceso y áreas de desplazamiento que se encuentran dentro del recinto del establecimiento tienen superficie pavimentada apta para el tráfico al que están destinadas. Art. 32 del D.S. N° 007-98-SA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 7, "orden": 7.03, "AspectoEvaluar": "El establecimiento es exclusivo para la actividad que realiza y no tiene conexión directa con viviendas y locales en los que se realicen actividades distintas a la producción de alimentos. Art. 31 del D.S. N° 007-98-SA. ", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 7, "orden": 7.04, "AspectoEvaluar": "La distribución de los ambientes permite un flujo ordenado en etapas nitidamente separadas, que contribuye a reducir al mínimo la contaminación cruzada por efecto de ciruclación de personal, equipos, utensilios, materiales, instrumentos de un área sucia hacia otra limpia o por la proximidad de los servicios higienicos a ambientes donde se manipulan o almacenan alimentos. Art. 36, 44 del D.S. N° 007-98-SA. Art. 9 de la R.M. N° 449-2006/MINSA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 7, "orden": 7.05, "AspectoEvaluar": "Las instalaciones o equipos accesorios o complementarios a la fabricación de alimentos y bebidas, susceptibles de provocar la contaminación de los productos, se ubican en ambientes separados de las áreas de producción. Art. 46 del D.S. N° 007-98-SA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 7, "orden": 7.06, "AspectoEvaluar": "Las aberturas que comunican con el exterior (ventanas, puertas, tragaluces, drenajes, ductos de ventilación) están construidas de manera que impiden la acumulación de suciedad, son fáciles de limpiar y están protegidas (con mallas, flejes en bordes de puertas, tapas metálicas en sumideros, trampas en drenajes), para evitar el acceso de insectos u otros animales. Art. 33.e, 57 de D. S. 007-98-SA. Art. 9 de la R.M. N° 449-2006/MINSA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 7, "orden": 7.07, "AspectoEvaluar": "Las instalaciones (pisos, paredes, extructuras auxiliares) se encuentran en buen estado limpieza. Se toman las precauciones necesarias para impedir que el alimento sea contaminado cuando se realiza la limpieza y desinfección. Los implementos de limpieza son de uso exclusivo del área. Art. 56 del D.S. N° 007-98-SA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 7, "orden": 7.08, "AspectoEvaluar": "El establecimiento está libre de insectos, roedores o evidencia de su presencia (heces, manchas, roeduras, telarañas, ootecas, otros), animales domésticos y silvestres (gatos, perros, aves, otros) o evidencia de su presencia (excretas, plumas, otros).En caso de encontrar evidencia(s), indicar la(s) área(s). ....................................................................................... Art. 57 del D.S. N° 007-98-SA. Art. 31.b, del D.S. N° 22-2001-SA-DM.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 7, "orden": 7.09, "AspectoEvaluar": "Los dispositivos de control de vectores (insectocutores, trampas, otros) se encuentran operativos y están ubicados en lugares donde los alimentos no están expuestos. Art. 57 del D.S. N° 007-98-SA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 7, "orden": 7.10, "AspectoEvaluar": "El establecimiento cuenta con un sistema que  garantiza una provisión permanente y suficiente de agua en todas sus instalaciones, para las operaciones de procesamiento y limpieza. Art. 40 del D.S. N° 007-98-SA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 7, "orden": 7.11, "AspectoEvaluar": "Los depósitos, cisternas y/o tanques de almacenamiento de agua se encuentran construidos, conservados y protegidos de manera que evite la contaminación. Art. 40, 56 del D.S. N° 007-98-SA. Art. 17, 18, 19 de la R.M. N° 449-2001-SA-DM.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 7, "orden": 7.12, "AspectoEvaluar": "El sistema de disposición de aguas servidas (pozos sépticos, alcantarillado, canaletas, sumideros, cajas de registro), se encuentra protegido contra el ingreso de roedores e insectos y está diseñado de manera que facilite su mantenimiento, limpieza, y evite la contaminación cruzada. Art. 42, 46, 57 del D.S. N° 007-98-SA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 7, "orden": 7.13, "AspectoEvaluar": "Las instalaciones para el almacenamiento central de residuos sólidos, se encuentran en ambientes separados de las áreas de producción y cuentan con recipientes de plástico o metálicos adecuadamente cubiertos o tapados, diseñados de tal manera que permitan su fácil y completa limpieza. Art. 43, 46 del D.S. N° 007-98-SA. Art. 9 de la R.M. N° 449-2006-MINSA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 7, "orden": 7.14, "AspectoEvaluar": "Toda plataforma, tolva, cámara o contenedor utilizado en el transporte de materias primas, ingredientes, aditivos, que requieren o no cadena de frío, se encuentra en buen estado de conservación, acondicionados a temperaturas de almacenamiento del producto, provistos de medios suficientes para proteger el alimento  de efectos del calor, humedad, sequedad u otro efecto indeseable. se someten a limpieza y desinfección así como desodorización, de ser necesario, antes de proceder a la carga del producto. Se verifica que el vehículo no se ha utilizado para transportar productos tóxicos, pesticidas, insecticidas u otra sustancia que pueda ocasionar contaminación. Art. 75, 76 del D.S. N° 007-98-SA. Art. 13 de la R.M. N° 449-2006/MINSA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 7, "orden": 7.15, "AspectoEvaluar": "Los procedimientos de carga, estiba y descarga de las materias primas, insumos, aditivos o producto final, se realizan aplicando buenas prácticas de manipulación por parte del personal, de tal manera que se evita la contaminación cruzada. Art. 49, 50, 52, 53, 77 del D.S. N° 007-98-SA.", "SI": "", "NO": "", "OBSERVACION": "" },

                    { "Grupo": 8, "orden": 8.01, "AspectoEvaluar": "Cuenta con procedimiento de limpieza, desinfección y mantenimiento de depósitos e instalaciones relacionadas con el manejo del agua (tanques, cisternas). Art. 40 del D.S. N° 007-98-SA. Art. 17, 18, 19 de la R.M. N° 449-2001-SA-DM. Art. 4 del D.S. N° 22-2001-SA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 8, "orden": 8.02, "AspectoEvaluar": "Cuenta con un plan de monitoreo de la calidad de agua utilizada en planta, que incluye análisis microbiológicos, físico químicos, bacteriológicos entre otros, que permite comprobar su aptitud para el consumo humano (Agua de consumo humano: agua apta para consumo humano y para todo uso domestico habitual, incluida la higiene personal). Verificar el cumplimiento de cronograma establecido. Indicar frecuencia y fecha de último análisis ....................  Art. 40 del D.S. N° 007-98-SA. Arts 60 y 61 del D.S. N° 031-2010-SA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 8, "orden": 8.03, "AspectoEvaluar": "En caso de usar cloro o solución clorada como desinfectante del agua para consumo humano, se controla el nivel de cloro libre residual. Indicar:Frecuencia de determinación .............................Nivel de cloro residual en el agua de sala de proceso obtenido durante la inspección ...................... ppm Art. 40 del D.S. N° 007-98-SA. Art. 66 del D.S. N° 031-2010-SA.  ", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 8, "orden": 8.04, "AspectoEvaluar": "En el caso de que el agua no proceda de una planta de tratamiento (indicar procedencia), recibe tratamiento(s) que garantiza su calidad microbiológica y fisicoquímica. Indicar tipo de tratamiento…………………………………. Art. 40 de D.S 007-98-SA. Art. 60 y 61 del D.S. N° 031-2010-SA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 8, "orden": 8.05, "AspectoEvaluar": "Cuenta con un programa de manejo y disposición final de residuos sólidos operativo y su procedimiento establece frecuencias de recojo, horarios, rutas de evacuación, transporte y disposición final de los mismos. Art. 43 del D.S. N° 007-98-SA. Art. 11 de la R.M. N° 449-2006/MINSA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 8, "orden": 8.06, "AspectoEvaluar": "Cuenta con un programa de control de plagas operativo, con registros al día y certificado de saneamiento vigente (desinfección, desinsectación, desratización), los rodenticidas e insecticidas utilizados son autorizados por el MINSA, y cuentan con planos de ubicación de los sistemas de control utilizados (trampas, insectocutores, ultrasonidos, otros) . Art. 57 del D.S. N° 007-98-SA. Art. 31.b, del D.S. N° 22-2001-SA-DM. Art. 11 de la R.M. N° 449-2006/MINSA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 8, "orden": 8.07, "AspectoEvaluar": "Cuenta con un Programa de Higiene y Saneamiento actualizado, que incluye  frecuencias y procedimientos de: Limpieza y desinfección de ambientes, equipos, utensilios y medios de transporte de alimentos. Indicar: Código ............................... Versión ............................ Fecha de última revisión ......................... Art. 56, 76 del D.S. N° 007-98-SA. Art. 11, 13 de la R.M. N° 449-2006/MINSA. Art. 2° del D.S. N° 004-2014-SA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 8, "orden": 8.08, "AspectoEvaluar": "Cuenta con procedimiento de manejo de productos de limpieza y desinfección que incluye un instructivo de su preparación y uso, de modo que no contamine los alimentos. Los productos de limpieza están autorizados por el MINSA y son apropiados al fin perseguido. Art. 56 del D.S. N° 007-98-SA. Art. 11 de la R.M. N° 449-2006-MINSA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 8, "orden": 8.09, "AspectoEvaluar": "Los registros de la higienización de ambientes, equipos, utensilios y medios de transporte, se encuentran al día. Art. 56, 76 del D.S. N° 007-98-SA. Art. 8, 11, 13 de la R.M. N° 449-2006/MINSA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 8, "orden": 8.10, "AspectoEvaluar": "Realiza la verificación de la eficacia del programa de higiene y saneamiento, mediante análisis microbiológico de superficies, equipos y ambientes (verificar si cuenta con un cronograma y si este se esta cumpliendo). Art. 56 del D.S. N° 007-98-SA. Art. 11 de R.M 449-2006-MINSA. Numeral 8 de la R.M. N° 461-2007/MINSA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 8, "orden": 8.11, "AspectoEvaluar": "Cuenta con un Manual de Buenas Prácticas de Manipulación o Buenas Prácticas de Manufactura actualizado. Indicar: Código ............................... Versión ............................ Fecha de última revisión ......................... Art. 2° del D.S. N° 004-2014-SA", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 8, "orden": 8.12, "AspectoEvaluar": "La empresa realiza un control médico en forma periódica, con la finalidad de asegurar que el personal no es portador de enfermedades  infectocontagiosa, y no tiene síntomas de ellas. Cumple con su cronograma o frecuencia. Indicar frecuencia ............... Art. 49 del D.S. N° 007-98-SA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 8, "orden": 8.13, "AspectoEvaluar": "Realiza el control de higiene y signos de enfermedad infectocontagiosa del personal. Esto se encuentra registrado. Indicar Frecuencia para ambos casos ……………………. Última fecha de control ………………………………….. Art. 49, 50 del D.S. N° 007-98-SA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 8, "orden": 8.14, "AspectoEvaluar": "Cuenta con un programa de formación o capacitación del personal, que incluya frecuencias de ejecución y temas de capacitación relacionados a: Inocuidad de los alimentos y peligros asociados, epidemiología de las ETAS, BPM en la cadena alimentaria, uso y mantenimiento de instrumentos y equipos, aplicación del PHyS, hábitos de higiene y presentación personal, control de procesos y riesgos asociados, sistema HACCP, rastreabilidad, otros que se consideren pertinentes: ............................ Art. 52 del D.S. N° 007-98-SA. Art. 12 de la R.M. N° 449-2006/MINSA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 8, "orden": 8.15, "AspectoEvaluar": "Cuenta con registros de capacitación del personal. que incluya un listado de los manipuladores actualizados y constancias de evaluación. Ultima Fecha: ......................................... Tema (s): ................................................. Frecuencia: ......................................... El personal que dicta la capacitación es: Interno (   ) o externo (  ) y está calificado. Art. 52 del D.S. N° 007-98-SA. Art. 8, 12 de la R.M. N° 449-2006/MINSA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 8, "orden": 8.16, "AspectoEvaluar": "Cuenta con un Programa de mantenimiento preventivo de equipos. Este programa contempla el cronograma al que deben someterse como mínimo los equipos que se utilizan en el control de los PCC. Los registros se encuentran al día. Indicar frecuencia: ................ Art. 60 del D.S. N° 007-98-SA. Art. 25 de la R.M. N° 449-2006/MINSA. ", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 8, "orden": 8.17, "AspectoEvaluar": "Cuenta con un Programa de calibración de instrumentos de medición. Incluye procedimientos y cronograma. Los registros se encuentran al día. Indicar: Frecuencia: .................................................. Ultima fecha de calibración: ..........................................  Art. 47, 60 del D.S. N° 007-98-SA. Art. 25 de la R.M. N° 449-2006/MINSA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 8, "orden": 8.18, "AspectoEvaluar": "Cuenta con un procedimiento de control de proveedores, así como el registro de proveedores validados, indicando la frecuencia en que éstos son evaluados. Indicar la modalidad de evaluación: Visita al establecimiento.  (  )Análisis de la materia prima.  (  )Registro Sanitario de los productos.  (  )Otros: ………………………. (  ) Art. 10.d de la R.M. N° 449-2006/MINSA. ", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 8, "orden": 8.19, "AspectoEvaluar": "Cuenta con registros de especificaciones técnicas y certificados de análisis de la materia prima e insumos recepcionados, y documentos que identifiquen su procedencia. Art. 60, 62, 63, 64 del D.S. N° 007-98-SA. Art. 10.d, 10.e de la R.M. N° 449-2006/MINSA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 8, "orden": 8.20, "AspectoEvaluar": "Los controles establecidos para la materia prima e insumos durante la recepción y/o antes de su uso (evaluación sensorial, certificados de análisis, medición de parámetros por métodos rápidos, otros), son suficientes para evidenciar que satisfacen los requisitos de calidad sanitaria e inocuidad. (Verificar registros). Art. 60, 62, 63 del D.S. N° 007-98-SA. Art. 10.d de la R.M. N° 449-2006/MINSA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 8, "orden": 8.21, "AspectoEvaluar": "Los envases primarios (que irán en contacto con el producto final) y las tintas empleadas en el rotulado de los mismos son de material inocuo, y están libres de olores o sustancias que puedan ser transferidas al producto, lo cual se demuestra con certificados y resultados de análisis. Indicar fechas: ............................................... Art. 64, 118, 119 del D.S. N° 007-98-SA. Art. 10.e de la R.M. N° 449-2006/MINSA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 8, "orden": 8.22, "AspectoEvaluar": "Cuenta con procedimiento de liberación de lotes del producto terminado. Verificar registros. Art. 58, 60, 61 del D.S. N° 007-98-SA. Art. 10.g  de la R.M. N° 449-2006/MINSA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 8, "orden": 8.23, "AspectoEvaluar": "Cuenta con procedimiento de recolección de producto final, que permite el retiro del mercado del lote que implique riesgo para la salud del consumidor. Verificar registros. Art. 60 del D.S. N° 007-98-SA. Art. 10.h, 26 de la R.M. N° 449-2006/MINSA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 8, "orden": 8.24, "AspectoEvaluar": "Cuenta con procedimiento de productos no conformes, que incluye la disposición final y/o destrucción de un alimento no apto, sujeta a la norma del MINSA. Verificar registros. Art. 60, 69 del D.S. N° 007-98-SA. Art. 26 de la R.M. N° 449-2006/MINSA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 8, "orden": 8.25, "AspectoEvaluar": "Los controles aplicados a los procesos específicos se encuentran debidamente registrados, los mismos que permiten realizar la rastreabilidad de los productos elaborados (hasta conocer los lotes de materia prima e insumos utilizados en la producción). Art. 60 del D.S. N° 007-98-SA. Art. 10.g, 14, 28 de la R.M. N° 449-2006/MINSA.", "SI": "", "NO": "", "OBSERVACION": "" },
                    { "Grupo": 8, "orden": 8.26, "AspectoEvaluar": "Existe un  profesional y/o técnico calificado y capacitado para dirigir y supervisar el control de las operaciones en todas las etapas de proceso. Art. 61 del D.S. N° 007-98-SA. Art. 10.f de la R.M. N° 449-2006/MINSA.", "SI": "", "NO": "", "OBSERVACION": "" },

            ],
            ListaFiltrada:[],
        },
        methods: {
            BuscarProcedimiento: function () {
                var pIni = $('#procedimientoInicio').val();
                var pFin = $('#procedimientoFin').val();

                if (pIni > pFin) {
                    Mensaje('El procedimiento inicial no puede ser mayor al procedimiento final', 2);
                    return;
                }

                var ListaProcedimientos = this.ListaProcedimiento.filter(x=> x.orden >= pIni);
                var ListaProcedimientos = ListaProcedimientos.filter(x=> x.orden <= pFin);
                this.ListaFiltrada = ListaProcedimientos;
                this.GenerarReporte();
                
            },
            ListarGrupos:function(){

            },
            GenerarReporte: function () {
                
                //{ "Grupo": 2, "orden": 2.16, "AspectoEvaluar": "dictamen", "SI": "", "NO": "X", "OBSERVACION": "Nada" },
                //];

                var fechainicial = $('#dfechaIni').data('date');
                var fechafinal = $('#dfechaFin').data('date');

                if (fechainicial > fechafinal) {
                    Mensaje('La fecha inicial no puede ser mayor a la fecha final', 2);
                    return;
                }


                //fechainicial = fechainicial.substr(3, 2) + "/" + fechainicial.substr(0, 2) + "/" + fechainicial.substr(6, 10);                
                //fechafinal = fechafinal.substr(3, 2) + "/" + fechafinal.substr(0, 2) + "/" + fechafinal.substr(6, 10);

                var R = {
                    fechainicial:fechainicial,
                    fechafinal: fechafinal
                };

                axios.post('/Reporte/GenerarReporte', R).then(response => {
                    var groupColumn = 0;

                    var _ListaProcedimiento = this.ListaFiltrada;

                    $.each(_ListaProcedimiento, function (k, v) {
                        var Row = response.data.listrm.find(x=> x.indice == v.orden);
                        if (Row != undefined) {
                            if (Row.estado == 0) {
                                v.NO = "X";
                            } else {
                                v.SI = "X";
                            }
                            v.OBSERVACION = Row.descripcion;
                        }
                    });
                    $('#tbReporte').DataTable().destroy();
                    var table = $('#tbReporte').DataTable({
                        "data": _ListaProcedimiento,
                        "columns": [
                            { data: "Grupo" },
                            { data: "orden", "width": "10%" },
                            { data: "AspectoEvaluar", "width": "50%" },
                            { data: "SI", "width": "5%" },
                            { data: "NO", "width": "5%" },
                            { data: "OBSERVACION", "width": "30%" },
                        ],
                        "columnDefs": [
                            { "visible": false, "targets": groupColumn }
                        ],
                        "order": [[groupColumn, 'asc']],
                        "displayLength": 10,
                        "drawCallback": function (settings) {
                            var api = this.api();
                            var rows = api.rows({ page: 'current' }).nodes();
                            var last = null;

                            api.column(groupColumn, { page: 'current' }).data().each(function (group, i) {
                                if (last !== group) {
                                    var Cabecera = Reportes.grupos.find(x=> x.Grupo == group);
                                    $(rows).eq(i).before(
                                        '<tr style="background-color: #ddd!important;"><td>' + group + '</td><td colspan="4">' + Cabecera.Descripcion + '</td></tr>'
                                    );

                                    last = group;
                                }
                            });
                        },
                        //buttons: [
                        //    {
                        //        extend: 'print',
                        //        customize: function (win) {
                        //            $(win.document.body)
                        //                .css('font-size', '10pt')
                        //                .prepend(
                        //                    '<img src="http://datatables.net/media/images/logo-fade.png" style="position:absolute; top:0; left:0;" />'
                        //                );

                        //            $(win.document.body).find('table')
                        //                .addClass('compact')
                        //                .css('font-size', 'inherit');
                        //        }
                        //    }
                        //]
                    });
                }).catch(error => {
                    console.log(error);
                    this.errored = true;
                });
            },
        },
        computed: {},
        created: function () {
            //this.GenerarReporte();
        },
        mounted: function () {
        }
    });

    $('#chkveg').multiselect({
        includeSelectAllOption: true
    });

    $('#btnget').click(function () {
        alert($('#chkveg').val());
    });


    $('#dfechaIni').datetimepicker({
        language: 'es',
        weekStart: 1,
        todayBtn: 1,
        autoclose: 1,
        todayHighlight: 1,
        startView: 2,
        minView: 2,
        forceParse: 0

    });

    $('#dfechaFin').datetimepicker({
        language: 'es',
        weekStart: 1,
        todayBtn: 1,
        autoclose: 1,
        todayHighlight: 1,
        startView: 2,
        minView: 2,
        forceParse: 0

    });
    
});

function printData() {
    var divToPrint = document.getElementById("RegionReporte");
    newWin = window.open("");
    newWin.document.write(divToPrint.outerHTML);
    newWin.print();
    newWin.close();
}

