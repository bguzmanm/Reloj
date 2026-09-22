# Reloj

Proyecto de Unity 6 (URP) en el que construimos un **reloj analógico funcional** paso a paso siguiendo el tutorial `1. Game Objects and Scripts (v2).md`.

El reloj se arma con primitivas (una esfera de UV actuando de esfera de reloj, cubos como indicadores de hora, cajas alargadas como manecillas) y se anima con un único script que lee la hora del sistema en tiempo real.

## Requisitos

- Unity **6000.5.8f1** (Unity 6 LTS) con soporte para URP.
- El proyecto usa el paquete de Universal Render Pipeline (`com.unity.render-pipelines.universal`).

## Cómo abrir y ejecutar

1. Abre el proyecto con Unity Hub seleccionando la carpeta del repo.
2. Abre la escena `Assets/Scenes/SampleScene.unity`.
3. Pulsa **Play**. Las manecillas deben girar marcando la hora actual.

## Estructura de la escena

La escena (`SampleScene.unity`) contiene un GameObject vacío llamado `Clock` como raíz de todo el reloj:

```
Clock (vacío)
├── Face (esfera de UV, negra, aplastada: scale 10, 0.2, 10)
├── Hour Indicator 1 … 12 (cubos oscuros en el borde)
├── Hours Arm Pivot      → Hours Arm
├── Minutes Arm Pivot    → Minutes Arm
└── Seconds Arm Pivot    → Seconds Arm (roja)
```

Cada manecilla cuelga de un **pivote vacío**: el script solo rota el pivote alrededor del eje Z, así las manecillas giran desde su base.

## Cómo funciona la animación

`Assets/Scripts/Clock.cs` (`Clock : MonoBehaviour`):

- En `Update()` lee `DateTime.Now`.
- Convierte las horas, minutos y segundos a grados:
  - Horas: `hoursToDegrees * time.Hour` (30° por hora)
  - Minutos: `minutesToDegrees * time.Minute` (6° por minuto)
  - Segundos: `secondsToDegrees * time.Second` (6° por segundo)
- Asigna la rotación a cada pivote: `Quaternion.Euler(0f, 0f, grados)`.

Los pivotes se asignan en el Inspector mediante `[SerializeField]`:

| Variable      | Objeto de la escena      |
|---------------|--------------------------|
| `hoursPivot`  | `Hours Arm Pivot`        |
| `minutesPivot`| `Minutes Arm Pivot`      |
| `secondsPivot`| `Seconds Arm Pivot`      |

> Nota: los indicadores están espejados con respecto a la esfera porque la cámara de la escena observa el reloj con un giro que invierte la imagen (yaw de ~194°). Las constantes del script son positivas (+30, +6, +6) para que la barrida 12 → 1 → 2 → 3 … tenga dirección horaria en pantalla.

## Materiales

- `Clock.mat` — esfera del reloj (blanca).
- `Hour Indicator.mat` — marcadores de las horas (gris oscuro).
- `Clock Arm.mat` — manecillas de horas y minutos (negro).
- `Seconds Arm.mat` — manecilla de segundos (rojo).

## Créditos

Tutorial: `1. Game Objects and Scripts (v2).md` (incluido en el repo).