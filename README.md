# Recorrido Virtual FEIRNNR - Versión VR (Standalone)

Este repositorio contiene el código fuente y los recursos del recorrido virtual inmersivo a escala real de los laboratorios del Edificio 2 de la Facultad de la Energía, las Industrias y los Recursos Naturales No Renovables (FEIRNNR). El simulador está diseñado y optimizado para ejecutarse de forma nativa e independiente (Standalone) en el visor Meta Quest 2.

Desde el enfoque de la computación aplicada, el proyecto resolvió el cuello de botella gráfico que supone renderizar geometría arquitectónica masiva en hardware móvil. Para ello, se integraron técnicas de optimización matemática espacial y reducción poligonal, logrando una experiencia fluida sin sacrificar la topología original de los laboratorios.

## 🛠️ Tecnologías y Versiones Utilizadas
* **Motor Gráfico:** Unity 6.0 (Versión 6000.0.59f2)
* **Pipeline Gráfico:** Universal Render Pipeline (URP)
* **Modelado y Topología Base:** Blender 4.4
* **Hardware Destino:** Meta Quest 2
* **Técnicas de Optimización Implementadas:**
  * **Level of Detail (LoD):** Decimación de mallas del mobiliario según la distancia de la cámara.
  * **Culling Espacial:** Descarte predictivo mediante *Frustum Culling* y *Occlusion Culling* (Celdas volumétricas horneadas).

## ⚙️ Requisitos del Sistema (Para Desarrollo)
* Unity Hub y Unity Editor `6000.0.59f2`.
* Módulo *Android Build Support* instalado en el editor de Unity.
* Visor Meta Quest 2 configurado en Modo Desarrollador.
* Git LFS instalado localmente.

## 📥 Guía de Instalación y Clonado (Requisito Obligatorio)
Este proyecto contiene modelos 3D y texturas de alta resolución. Para garantizar la correcta descarga, **es estrictamente necesario tener Git LFS (Large File Storage) instalado**.

Ejecuta los siguientes comandos en tu terminal en este orden exacto:

1. `git lfs install`
2. `git clone https://github.com/Davud404/RecorridoLabs2.git`
3. `cd [NOMBRE_DE_LA_CARPETA]`
4. `git lfs pull`

## 📦 Exportación (Build)
Para compilar una nueva versión ejecutable `.apk`:
1. Abre el proyecto en Unity.
2. Ve a `File > Build Settings`.
3. Plataforma activa: **Android**.
4. Verifica que la escena principal esté en *Scenes in Build*.
5. Haz clic en **Build** y utiliza SideQuest o Meta Quest Developer Hub para instalar el `.apk`.
