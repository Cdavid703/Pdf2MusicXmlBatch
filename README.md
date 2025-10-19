# 🎼 PDF → MusicXML Batch Converter (Audiveris Automation)

> 🎵 Convierte de forma **masiva** tus partituras en PDF a formato **MusicXML**, listas para editar en programas como **Finale, MuseScore o Sibelius**.  
> Este proyecto integra **Audiveris** (OCR musical) con una interfaz gráfica en **C# (Windows Forms)**, para que puedas automatizar todo con un solo clic.

---

## 🚀 ¿Qué hace esta aplicación?

- 🧩 **Procesamiento por lotes (masivo):** selecciona una carpeta llena de PDFs y convierte **todos de una sola vez**.  
- 🤖 **Integra Audiveris en modo batch:** usa `audiveris.bat` para convertir sin abrir la interfaz GUI.  
- 🧾 **Detección automática:** indica qué archivos se convirtieron correctamente y cuáles tuvieron errores.  
- 📂 **Salida organizada:** todos los archivos `.musicxml` se guardan en tu carpeta elegida, listos para editar.  
- 💡 **Registro automático:** si algo falla, se genera un archivo `audiveris_log.txt` con el detalle.

---

## 🖥️ Interfaz simple y eficiente

La app te permite:
1. Seleccionar la **carpeta de partituras PDF** 🎶  
2. Elegir la **carpeta de salida** 📂  
3. Indicar la **ruta del archivo `audiveris.bat`** ⚙️  
4. Presionar **“Convertir todo”** y relajarte mientras el programa hace el trabajo 🧙‍♂️

---

## ⚙️ Requisitos

| Requisito | Versión recomendada |
|------------|----------------------|
| **Windows** | 10 o 11 (64 bits) |
| **Java JDK** | 17 o superior |
| **Audiveris** | 5.2.2 (modo consola con `audiveris.bat`) |
| **.NET Framework / .NET 6+** | Según versión de Visual Studio usada |

---

## 🧠 Cómo funciona internamente

El programa ejecuta Audiveris desde C# mediante:
```bash
audiveris.bat -batch -export -output "CarpetaSalida" "Archivo.pdf"

🎯 Ejemplo de uso

Coloca tus partituras PDF en una carpeta, por ejemplo:
C:\Users\USER\Downloads\partituras

Configura la carpeta de salida:
C:\Users\USER\Documents\Partituras\Guardia

Indica el ejecutable de Audiveris (modo batch):
C:\Program Files\Audiveris\bin\audiveris.bat

Presiona Convertir todo

Obtén todos tus .musicxml listos 🎶

✨ Características futuras (roadmap)

 Barra de progreso individual por archivo

 Integración con Tesseract OCR 5

 Soporte para arrastrar y soltar PDFs

 Exportación directa a .mxl comprimido

 Botón “Probar Audiveris” para verificar configuración


🧑‍💻 Autor

Desarrollado con cariño por Cdavid703
💬 “Porque automatizar la música también es arte.”
