# Animus Awakening — Plan completo de Fase 1

**Estado:** propuesta ejecutable v1.1  
**Motor:** Unreal Engine 5.8  
**Plataforma objetivo:** PC  
**Tipo de entrega:** vertical slice multijugador persistente  
**Escala de prueba:** 2–8 jugadores concurrentes en un servidor dedicado

## 1. Propósito de la fase

La Fase 1 no busca producir un MMORPG completo. Busca demostrar, de extremo a extremo, que sus fundamentos más arriesgados funcionan juntos:

1. Entrar con un personaje.
2. Compartir una zona con otros jugadores.
3. Explorar, combatir, recibir una misión y obtener botín.
4. Equipar, comprar, vender y gastar recursos.
5. Desconectarse y volver sin perder el progreso.
6. Repetir todo lo anterior sin romper sistemas ya validados.

La entrega debe sentirse como una pequeña muestra de un MMO, no como una colección de sistemas aislados.

## 2. Estado inicial observado

- El proyecto está asociado a Unreal Engine 5.8.
- Parte de la plantilla Top Down continúa siendo el mapa y modo de juego predeterminados.
- También existen variantes Twin Stick y Strategy provenientes de la plantilla.
- Hay un único módulo Runtime principal y todavía no existe un target de servidor dedicado.
- StateTree, Gameplay StateTree y el plugin MCP están habilitados.
- Gameplay Ability System, una capa backend y una base de datos aún no forman parte del proyecto.
- No se detectó un repositorio Git en la raíz; el control de versiones es el primer requisito técnico.
- El MCP responde en esta sesión, pero actualmente solo publica su toolset de gestión de skills; la automatización directa del editor debe verificarse antes de depender de ella.

## 3. Visión de producto provisional

### Fantasía

Un mundo de exploradores que desarrollan una fuerza interior altamente personal, aceptan contratos peligrosos, descubren territorios extraordinarios y forman alianzas o rivalidades. La inspiración es el género de aventura y progresión estratégica, pero el universo, personajes, terminología, iconografía, reglas y argumento deben ser propios.

### Pilares

1. **Poder personal expresivo:** pocas habilidades, combinaciones relevantes y decisiones visibles.
2. **Exploración con riesgo:** el mundo ofrece información, rutas, criaturas y eventos que recompensan la preparación.
3. **Cooperación útil:** jugar acompañado abre tácticas, no solo aumenta números.
4. **Progreso legible:** cada sesión de 20–30 minutos produce una mejora o una decisión significativa.
5. **Economía confiable:** todo recurso importante tiene origen, destino y registro auditable.

### Modelo jugable confirmado para Fase 1

- Cámara top-down de perspectiva elevada, con inclinación fija y zoom limitado.
- Click-to-move como control inicial, aprovechando la base existente; un perfil de movimiento directo con teclado se compara durante el gimnasio de control.
- Combate top-down en tiempo real: selección y apuntado mediante cursor, indicadores de área en el suelo y barra corta de habilidades.
- Servidor dedicado autoritativo.
- Personaje sin clase rígida al comienzo; las especializaciones definitivas se diseñarán después de validar el combate base.

La perspectiva top-down ya es una decisión de producto. El playtest debe decidir únicamente la modalidad principal de movimiento, el grado de rotación permitido y las reglas de selección/apuntado antes de crear grandes cantidades de animaciones o contenido.

## 4. Protección de propiedad intelectual

Cambiar nombres de una obra existente no es suficiente. Esta fase debe crear y conservar un **registro de originalidad**.

### Reglas

- No copiar nombres, personajes, apariencias, siluetas reconocibles, emblemas, mapas, diálogos, música, escenas, organizaciones ni arcos argumentales.
- No reproducir de forma uno-a-uno la taxonomía, pruebas, técnicas o restricciones del sistema de poderes de otra obra.
- Las referencias deben describirse como objetivos generales: aventura, especialización personal, combate mental, exploración y mundo peligroso.
- Toda pieza de lore debe poder explicarse sin mencionar la obra inspiradora.
- Mantener una tabla de procedencia para nombres, diseños y mecánicas clave.
- Antes de una demo pública o comercial, realizar una revisión profesional de marca, copyright y términos de las tiendas. Este documento no sustituye asesoramiento legal.

### Prueba de aceptación IP-01

Un revisor que reciba únicamente el material del juego puede describir su mundo, poderes, personajes y conflicto sin necesitar equivalencias con una franquicia ajena. Cualquier elemento que solo se entienda como “el equivalente de X” vuelve a diseño.

## 5. Alcance exacto del vertical slice

### Incluido

- Un refugio seguro pequeño.
- Una zona exterior explorable.
- Una arena o prueba instanciada.
- Entre 20 y 30 minutos de recorrido jugable repetible.
- Creación limitada de personaje y selección de un perfil inicial.
- Progresión de nivel 1 a 5.
- Un recurso de combate y cuatro acciones de combate equipadas.
- Tres familias de enemigos y un élite.
- Cinco misiones: introducción, exploración, combate, recolección y élite.
- Inventario por ranuras, equipo, botín, consumible y vendedor.
- Una receta de fabricación simple.
- Una moneda principal y una divisa de progresión ligada al personaje.
- Grupo de hasta cuatro jugadores y chat de grupo/local básico.
- Persistencia de personaje, inventario, divisas, equipo, misión y posición segura.
- Telemetría de combate, progresión y economía.
- Builds de cliente y servidor dedicado para Windows.

### Fuera de alcance

- Mundo enorme o totalmente continuo.
- Cientos o miles de jugadores concurrentes.
- PvP competitivo, guerras de gremio, raids y world bosses.
- Gremios, correo, banco, housing, monturas y mascotas.
- Casa de subastas, comercio directo y economía entre servidores.
- Moneda premium, tienda, battle pass, loot boxes o monetización.
- Voz, moderación avanzada, anticheat comercial y soporte multirregión.
- Seis o más especializaciones completas.
- Pipeline final de arte, cinemáticas o doblaje.

Excluir estos sistemas es una condición del éxito, no una deuda accidental.

## 6. Arquitectura objetivo de Fase 1

### Mundo

Se recomienda un **mundo abierto por zonas conectadas con instancias**:

- World Partition dentro de zonas exteriores que realmente lo necesiten.
- Refugios y regiones como unidades desplegables independientes.
- Pruebas, mazmorras y encuentros importantes como instancias.
- Transiciones controladas entre zonas, con posibilidad futura de distribuirlas entre procesos.

Un mapa mundial único y gigantesco dificultaría el desarrollo, las pruebas, el despliegue y el escalado.

### Autoridad

- El cliente solicita acciones y presenta resultados.
- El servidor valida movimiento, objetivos, cooldowns, daño, botín, inventario y divisas.
- El cliente nunca decide resultados económicos ni de progresión.
- Las operaciones críticas incluyen identificador idempotente para que un reintento no duplique recompensas.

### Capas

| Capa | Responsabilidad |
|---|---|
| Cliente UE | Entrada, cámara, UI, predicción y presentación |
| Servidor dedicado UE | Simulación autoritativa de zona, combate, IA y sesiones |
| Servicio backend | Identidad de desarrollo, personajes, persistencia y transacciones |
| PostgreSQL | Fuente de verdad de personajes, inventario, divisas, misiones y auditoría |
| Telemetría | Eventos versionados, métricas y detección de anomalías |

El servidor de juego no debe exponer credenciales de base de datos al cliente. El stack exacto del servicio backend se decide mediante un spike técnico corto y un ADR antes de implementarlo.

### Organización Unreal

- C++ para autoridad, contratos, replicación, persistencia y código con pruebas.
- Blueprints para ensamblaje, UI, animación y contenido.
- Gameplay Ability System para atributos, efectos, costes, cooldowns y habilidades.
- Gameplay Tags como vocabulario compartido.
- Primary Data Assets para habilidades, objetos, enemigos y misiones.
- StateTree para comportamiento de IA.
- Código dirigido por eventos; evitar Tick cuando no sea indispensable.
- Un módulo de pruebas separado del Runtime.

## 7. Estrategia de pruebas acumulativas

Cada sección crea una suite nueva. Una sección solo se cierra cuando:

1. Su suite nueva pasa.
2. Todas las suites anteriores vuelven a pasar.
3. No hay errores nuevos en logs.
4. La evidencia se adjunta al hito: build, reporte de pruebas, captura o métrica.

### Suites

| ID | Suite | Tipo |
|---|---|---|
| R0 | Salud del proyecto | Compilación, cook y smoke |
| R1 | Control del personaje | Automation + Functional Test |
| R2 | Autoridad multijugador | Dedicated server + 2 clientes + pruebas negativas |
| R3 | Mundo y transición | Functional + viaje/reconexión |
| R4 | Atributos y habilidades | Unit/Spec + red |
| R5 | Combate e IA | Unit + Functional + determinismo |
| R6 | Misiones, objetos y economía | Unit + invariantes transaccionales |
| R7 | Persistencia | Integración backend/DB + fallos inducidos |
| R8 | UI y social | Functional + accesibilidad básica |
| R9 | Rendimiento y estabilidad | Gauntlet/soak/perfilado |
| E2E | Recorrido completo | Cliente–servidor–backend–DB |

### Pirámide mínima

- Muchas pruebas rápidas sobre reglas puras y validación de Data Assets.
- Pruebas funcionales dentro de mapas pequeños, dedicados a un solo sistema.
- Pruebas multiproceso para replicación y reconexión.
- Pocos recorridos E2E, pero obligatorios antes de integrar una sección.

Los mapas de prueba no se reutilizan como mapas finales de contenido.

## 8. Secciones de ejecución

## Sección 0 — Carta de producto y originalidad

**Objetivo:** convertir la inspiración en reglas propias y congelar el alcance.

### Entregables

- One-page de visión.
- Glosario provisional original.
- Matriz “inspiración general / expresión propia / elementos prohibidos”.
- Pilares y anti-pilares.
- Lista cerrada de incluido/fuera de alcance.
- Registro de decisiones arquitectónicas (ADR).

### Pruebas

- IP-01 aprobada.
- Cada feature incluida sostiene al menos un pilar.
- Cada feature fuera de alcance está ausente del backlog de Fase 1.
- Revisión de alcance: ninguna tarea estimada supera cinco días sin subdividirse.

### Puerta de salida

No comenzar producción de arte reconocible hasta aprobar el registro de originalidad.

## Sección 1 — Base reproducible del proyecto

**Objetivo:** poder cambiar el proyecto sin miedo y reconstruirlo desde cero.

### Entregables

- Inicializar Git y Git LFS con reglas apropiadas para Unreal.
- Establecer ramas y revisión de cambios.
- Renombrar metadatos heredados de “Top Down Game Template”.
- Separar contenido de plantilla como prototipo heredado, sin borrarlo antes de tener baseline.
- Target de cliente, editor y servidor dedicado.
- Configuración Development y Test.
- Módulo de pruebas y primer Automation Test.
- Convenciones de nombres, carpetas, Gameplay Tags y logs.
- Script o CI que compile, ejecute pruebas y haga cook de una build mínima.

### Pruebas R0

- Editor compila desde un checkout limpio.
- Cliente y servidor dedicado compilan.
- Cook mínimo termina sin error.
- El mapa smoke abre, espera 30 segundos y cierra sin crash.
- Cero referencias rotas y cero errores nuevos en log.

### Regresión al cerrar

- IP-01 + R0.

## Sección 2 — Personaje, cámara top-down e interacción

**Objetivo:** validar la sensación básica antes de construir sistemas caros.

### Entregables

- Personaje C++ base y Blueprint de presentación.
- Cámara top-down con inclinación fija, zoom limitado y encuadre que prioriza legibilidad del combate.
- Click-to-move inicial sobre NavMesh, cancelación de destino y feedback visual de punto alcanzable/no alcanzable.
- Perfil alternativo de movimiento directo con teclado para compararlo sin reescribir el personaje.
- Conversión robusta de cursor a mundo para selección, interacción, dirección de ataque y habilidades de área.
- Enhanced Input para movimiento, zoom, rotación si se aprueba, evasión, interacción y habilidades.
- Interfaz de interacción por contrato, no por casteos específicos.
- Animación temporal: idle, caminar, correr, giro, ataque y evasión.
- Tratamiento provisional de oclusión: ocultar o transparentar techos y obstáculos que bloqueen al personaje.
- Ajustes básicos de accesibilidad: remapeo, velocidad de desplazamiento, mantener/pulsar y perfil click-to-move/teclado.
- Gimnasio gris de movimiento.

### Pruebas R1

- Click-to-move llega a destinos válidos, rechaza destinos imposibles y puede cancelarse sin estados atascados.
- Click sobre UI nunca produce movimiento ni lanza habilidades en el mundo.
- La proyección cursor–mundo mantiene precisión en los extremos del zoom y de la pantalla.
- El perfil de teclado permite movimiento en ocho direcciones sin alterar las reglas de servidor.
- Cámara, zoom y posible rotación no pierden al personaje ni atraviesan límites configurados.
- Techos y obstáculos no ocultan al personaje o amenazas críticas durante el recorrido de prueba.
- Reasignar una tecla persiste durante la sesión.
- Interacción fuera de rango es rechazada.
- Un objeto destruido durante una interacción no causa crash.
- Cien ciclos de mover–atacar–evadir–interactuar sin referencias inválidas.
- Playtest ciego: tres usuarios completan el gimnasio sin explicación oral y se registra la preferencia/eficacia de click-to-move frente a teclado.

### Regresión al cerrar

- R0 + R1.

## Sección 3 — Multijugador autoritativo

**Objetivo:** demostrar que el juego base funciona en servidor dedicado, no solo en PIE local.

### Entregables

- Flujo de conexión de desarrollo.
- GameMode, GameState, PlayerState y PlayerController con responsabilidades claras.
- Spawn, posesión, desconexión y limpieza.
- Replicación de destino, movimiento, orientación hacia cursor/objetivo y acciones.
- Relevancia y frecuencia de red configurables.
- Herramientas para simular latencia, jitter y pérdida.

### Pruebas R2

- Dos clientes externos conectan a un servidor dedicado.
- Ambos se ven mover, interactuar y desconectar correctamente.
- A 150 ms de latencia y 2% de pérdida no hay duplicación de acciones.
- El cliente que solicita una ruta imposible, velocidad, teletransporte o cooldown inválido es rechazado.
- Desconectar durante una acción no deja actor huérfano.
- Repetir 25 ciclos de conexión/desconexión no aumenta actores ni sesiones activas.

### Regresión al cerrar

- R0 + R1 ejecutadas también en servidor dedicado + R2.

## Sección 4 — Mundo, zonas y viaje

**Objetivo:** crear un territorio pequeño que represente la futura topología del MMO.

### Entregables

- Refugio seguro gris.
- Zona exterior gris con tres puntos de interés.
- Instancia de prueba gris.
- Reglas de zona segura, zona hostil y entrada a instancia.
- World Partition/Data Layers solo donde aporten valor.
- Spawn points y safe-return points.
- Navegación y límites de mundo.
- Presupuesto de actores replicados por zona.

### Pruebas R3

- Entrar y salir de las tres áreas conserva identidad y estado permitido.
- Dos jugadores viajan juntos y terminan en la instancia correcta.
- Caer fuera del mundo devuelve al último punto seguro.
- Un paquete de contenido ausente produce error controlado, no pérdida de personaje.
- Cincuenta transiciones consecutivas no filtran memoria ni duplican actores.
- IA y navegación funcionan después de cargar/descargar celdas.

### Regresión al cerrar

- R0–R3 completas.

## Sección 5 — Modelo de personaje, progresión y habilidades

**Objetivo:** construir una base de poder original y data-driven.

### Entregables

- Habilitar y encapsular Gameplay Ability System.
- Atributos mínimos: salud, recurso de combate, potencia, defensa y precisión.
- Curva de experiencia 1–5.
- Gameplay Tags y reglas de estado: vivo, derrotado, invulnerable, bloqueado y controlado.
- Cuatro acciones: ataque base, evasión/defensa, técnica activa y técnica característica.
- Coste, cooldown, cancelación e interrupción.
- Un perfil inicial funcional; los perfiles adicionales son datos de prueba, no contenido final.
- Respawn y recuperación.

### Pruebas R4

- Atributos nunca exceden límites ni quedan en NaN/negativo inválido.
- Coste y cooldown se aplican exactamente una vez en servidor.
- Activar una técnica sin recurso, muerto o controlado es rechazado.
- Buffs/debuffs expiran y se replican en el orden esperado.
- Subir de nivel recalcula valores derivados sin reescribir los valores base persistidos.
- Matar/revivir 100 veces no acumula efectos ni delegates.

### Regresión al cerrar

- R0–R4 completas.

## Sección 6 — Combate, IA y encuentro élite

**Objetivo:** validar el loop de habilidad, riesgo y cooperación.

### Entregables

- Pipeline de daño y curación autoritativo.
- Hit validation, selección por cursor, habilidades dirigidas al suelo y ventanas de invulnerabilidad.
- Tres enemigos: perseguidor cuerpo a cuerpo, hostigador a distancia y controlador.
- Un enemigo élite con dos fases simples.
- StateTrees, percepción, aggro, leash, muerte y respawn.
- Tabla de encuentro y métricas: duración, daño recibido, derrotas y uso de habilidades.

### Pruebas R5

- El mismo seed y estado inicial producen el mismo resultado de reglas puras.
- Daño duplicado, golpe fuera de rango y objetivo muerto se rechazan.
- Dos clientes golpeando en el mismo frame otorgan una sola muerte y un solo loot event.
- IA pierde aggro y vuelve a su origen sin quedar bloqueada.
- El élite puede completarse solo con dificultad y en grupo con ventaja táctica, sin escalar de forma absurda.
- 30 IA activas y 8 jugadores cumplen el presupuesto provisional del servidor.

### Regresión al cerrar

- R0–R5 completas.

## Sección 7 — Misiones, botín, inventario y economía cerrada

**Objetivo:** cerrar el primer ciclo de progreso sin abrir todavía comercio entre jugadores.

### Entregables

- Primary Data Assets versionados para objeto, loot table, misión, NPC y receta.
- Inventario por ranuras, stacks, equipamiento y consumibles.
- Estados de misión: disponible, aceptada, en progreso, completada y entregada.
- Una moneda principal comerciable futura, usada ahora con NPC.
- Una divisa ligada al personaje para progreso.
- Faucets: misión, enemigo y venta de objetos basura.
- Sinks: consumible, reparación o servicio y fabricación.
- Vendedor compra/vende y una receta.
- Libro mayor append-only para cada cambio de objeto o divisa.
- Hoja de simulación fuente/sumidero; objetivo inicial de razón 1.05–1.15 para el jugador mediano simulado.

No se implementan moneda premium, subastas ni trade directo.

### Pruebas R6

- Ningún objeto ocupa dos ranuras y ninguna ranura contiene dos instancias incompatibles.
- Un stack nunca supera su máximo ni baja de cero.
- Inventario lleno rechaza el loot o lo deriva al mecanismo definido sin perderlo silenciosamente.
- Entregar dos veces una misión produce una sola recompensa.
- Comprar, vender y fabricar mantienen la igualdad `saldo_final = saldo_inicial + movimientos_del_ledger`.
- Un vendedor nunca compra un objeto por más de su precio de venta equivalente.
- 10.000 simulaciones de sesión mantienen faucets/sinks dentro del rango objetivo o generan alerta.
- Todos los Data Assets inválidos fallan validación antes del cook.

### Regresión al cerrar

- R0–R6 completas.

## Sección 8 — Backend y persistencia segura

**Objetivo:** salir, volver y recuperar el mismo personaje sin duplicaciones.

### Entregables

- ADR de tecnología backend y protocolo.
- Identidad de desarrollo; autenticación pública queda fuera de esta fase.
- PostgreSQL con migraciones versionadas.
- Tablas mínimas: accounts/dev identities, characters, base stats, inventory, balances/ledger, quest progress y schema migrations.
- Ningún stat derivado persistido.
- Escritura síncrona y atómica para objetos/divisas.
- Guardado por lotes de posición/progreso no crítico.
- Tokens de sesión almacenados solo como hash si se usan.
- Claves idempotentes y auditoría en operaciones críticas.
- Herramienta de seed y restauración de datos de prueba.

### Pruebas R7

- Crear, cargar, modificar y recargar personaje conserva exactamente el estado esperado.
- Desconectar durante loot, compra, venta y entrega de misión no duplica ni pierde transacciones confirmadas.
- Repetir la misma petición idempotente 100 veces produce un solo efecto.
- Caída del backend muestra error recuperable; el servidor no inventa éxito.
- Reinicio del servidor recupera posiciones seguras y estado crítico.
- Migrar esquema hacia adelante conserva datos; rollback de entorno de prueba restaura la versión anterior cuando esté soportado.
- Consultas de inventario y personaje cumplen el presupuesto de latencia acordado en entorno local reproducible.

### Regresión al cerrar

- R0–R7 completas, con R6 validada contra PostgreSQL real y no mocks.

## Sección 9 — UI, grupo y comunicación

**Objetivo:** hacer comprensible y social el recorrido completo.

### Entregables

- HUD: salud, recurso, habilidades, objetivo e interacción.
- Inventario, equipo, misión, vendedor y panel de resultados.
- Feedback de latencia, reconexión y errores del backend.
- Grupo de hasta cuatro jugadores.
- Chat local y de grupo con límites de frecuencia.
- Bloqueo/mute de sesión básico.
- Escalado de UI, subtítulos y alternativas a información solo por color.

### Pruebas R8

- Navegación completa con teclado y ratón.
- UI en 1920×1080 y una resolución mínima acordada sin solapamientos críticos.
- Abrir/cerrar paneles 500 veces no incrementa widgets vivos.
- Invitación simultánea, rechazo, salida y caída del líder dejan un grupo válido.
- Rate limit rechaza spam sin afectar mensajes normales.
- Mensajes de error no exponen datos internos ni credenciales.
- Un usuario nuevo completa misión, equipo, compra y entrada a instancia sin ayuda del desarrollador.

### Regresión al cerrar

- R0–R8 completas.

## Sección 10 — Telemetría, seguridad y rendimiento

**Objetivo:** medir antes de balancear y conocer el límite real del slice.

### Entregables

- Esquema de eventos versionado.
- Eventos de sesión, combate, misión, loot, cambio de divisa, compra/venta y errores.
- Correlation ID de cliente, servidor y backend sin datos personales innecesarios.
- Alertas por creación de moneda superior al máximo teórico y diferencias de ledger.
- Presupuestos de frame, servidor, red, memoria y carga.
- Prueba automatizada de 8 clientes/bots.
- Procedimiento de respuesta a exploit: deshabilitar economía, identificar, restaurar y comunicar.

### Presupuestos provisionales

- Cliente: 60 FPS a 1080p en el hardware de referencia que debe documentarse.
- Servidor: tick estable acordado, inicialmente 30 Hz, con p95 por debajo de su frame budget.
- Escala slice: 8 jugadores, 30 IA activas y la zona exterior.
- Soak: 2 horas sin crash, crecimiento continuo de memoria ni divergencia económica.

Los números se congelan solo después de medir el hardware de referencia.

### Pruebas R9

- Los eventos no se duplican al reconectar.
- El ledger y la telemetría cuadran para todas las operaciones de la prueba.
- 8 clientes completan el circuito durante 2 horas.
- No hay crecimiento monotónico no explicado de memoria, actores, sesiones o handles.
- El perfil identifica y registra los tres cuellos de botella principales.
- Una petición cliente manipulada no puede crear XP, objetos o divisas.

### Regresión al cerrar

- R0–R9 completas.

## Sección 11 — Integración de contenido y puerta de Fase 1

**Objetivo:** sustituir el gris esencial por una experiencia coherente y decidir si el proyecto merece escalar.

### Entregables

- Pase visual limitado y original para refugio, exterior, instancia, personaje y cuatro enemigos.
- Audio temporal con licencias registradas.
- Tutorial contextual corto.
- Recorrido E2E automatizado y recorrido humano.
- Build versionada de cliente y servidor.
- Informe de playtest, rendimiento, economía, fallos y riesgos.
- Backlog de Fase 2 basado en evidencia.

### Prueba E2E obligatoria

1. Arrancar servicios y servidor desde entorno limpio.
2. Conectar dos cuentas de prueba.
3. Crear y cargar personajes.
4. Formar grupo.
5. Aceptar una misión.
6. Viajar a la zona exterior.
7. Combatir y obtener loot.
8. Completar el élite instanciado.
9. Regresar, equipar, vender, fabricar y entregar misión.
10. Cerrar ambos clientes de forma normal y forzada.
11. Reiniciar servidor y backend.
12. Reconectar y verificar personaje, misión, inventario, equipo y balances.
13. Cuadrar todos los cambios contra el ledger.

### Criterios de salida de Fase 1

- El E2E pasa tres veces consecutivas desde un entorno limpio.
- R0–R9 están verdes.
- Dos a ocho jugadores completan el loop sin intervención del desarrollador.
- No existe bug conocido P0 o P1 de crash, pérdida, duplicación o autoridad.
- El soak de dos horas cumple los presupuestos provisionales.
- El estado crítico sobrevive a desconexión y reinicio.
- El playtest confirma que movimiento, combate y progresión justifican iterar.
- La revisión de originalidad no identifica una dependencia esencial de IP ajena.

Si estos criterios no se cumplen, no se añade mundo, clases ni economía social: se corrigen los fundamentos.

## 9. Orden, tamaño y estimación

| Orden | Sección | Tamaño relativo | Evidencia visible |
|---:|---|---|---|
| 0 | Carta e IP | S | Documento y glosario |
| 1 | Base reproducible | M | Build + test smoke |
| 2 | Personaje/cámara top-down | M | Gimnasio jugable |
| 3 | Multijugador | L | Dos clientes en dedicado |
| 4 | Mundo/zonas | M | Viaje refugio–exterior–instancia |
| 5 | Progresión/habilidades | L | Nivel 1–5 y cuatro acciones |
| 6 | Combate/IA | L | Encuentro élite cooperativo |
| 7 | Loop/economía | L | Misión–loot–vendedor–craft |
| 8 | Persistencia | L/XL | Reconexión sin pérdida/dupe |
| 9 | UI/social | M/L | Recorrido comprensible en grupo |
| 10 | Telemetría/perf | M/L | Dashboard y soak |
| 11 | Integración | L | Build de evaluación |

Estimación orientativa: **20–28 semanas para una persona experimentada a tiempo completo**, o **10–16 semanas para un equipo pequeño de 3 personas** con perfiles complementarios. Debe reestimarse al terminar las secciones 2, 3 y 8, porque control, networking y persistencia son los principales multiplicadores de riesgo.

Cada hito debería durar entre tres y diez días laborables. Si supera ese tamaño, se subdivide manteniendo una demo visible.

## 10. Definition of Done común

Una tarea no está terminada por “funcionar en mi máquina”. Debe cumplir:

- Código compilado sin errores.
- Prueba automática o funcional relevante.
- Suite de regresión acumulativa verde.
- Ejecución en servidor dedicado cuando afecte gameplay.
- Logs sin errores nuevos.
- Data Assets validados.
- Sin lógica económica o de combate confiada al cliente.
- Documentación corta de decisión si cambia un contrato.
- Evidencia adjunta al hito.
- Cambio pequeño y reversible en control de versiones.

## 11. Riesgos principales y mitigación

| Riesgo | Señal temprana | Mitigación en Fase 1 |
|---|---|---|
| Alcance MMO infinito | Se agregan features sin completar E2E | Lista cerrada y gate por sección |
| Juego derivativo | Diseño explicado mediante equivalencias | Registro de originalidad e IP-01 |
| Combate sin identidad | Playtest confuso o pasivo | Validarlo en gris antes de arte |
| Autoridad incorrecta | El cliente decide daño/loot | Servidor dedicado desde sección 3 |
| Duplicación/pérdida | Balances no cuadran | Atomicidad, idempotencia y ledger |
| Mundo monolítico | Cook, memoria y viajes frágiles | Zonas e instancias pequeñas |
| Blueprint difícil de probar | Reglas críticas dispersas | C++ para reglas; BP para presentación |
| Economía inflacionaria | Faucets sin sinks ni métricas | Simulación y telemetría antes de trade |
| Infraestructura prematura | Kubernetes/microservicios antes del loop | Un backend modular y una DB en Fase 1 |
| Arte desperdiciado | Cambia movimiento, targeting o combate tarde | Top-down confirmado y graybox hasta aprobar R5 |
| Ausencia de control de versiones | Cambios irreversibles | Git/LFS antes de tocar arquitectura |

## 12. Tablero de trabajo recomendado

Columnas:

`Ideas → Ready → En curso → Revisión → Tests acumulativos → Hecho`

Cada tarjeta debe incluir:

- Resultado observable.
- Dependencias.
- Criterios de aceptación.
- Suite que agrega o modifica.
- Riesgo de autoridad/persistencia/economía.
- Evidencia requerida.

Límites de trabajo en curso:

- Una sola sección estructural activa.
- Máximo dos features jugables simultáneas.
- Cualquier bug de pérdida, duplicación o autoridad bloquea nuevas features.

## 13. Primer bloque concreto de trabajo

### Hito 1 — Baseline seguro

1. Crear repositorio Git/LFS y primer commit verificable.
2. Capturar build y smoke test de la plantilla actual.
3. Corregir nombre y metadatos del proyecto.
4. Crear carpeta/módulo de pruebas.
5. Añadir target de servidor dedicado.
6. Automatizar build mínima de cliente/servidor.

**Demo:** servidor dedicado inicia, un cliente conecta a un mapa vacío y una prueba automática queda verde.

### Hito 2 — Gimnasio de control

1. Crear mapa gris independiente.
2. Adaptar el personaje y controlador Top Down existentes al contrato definitivo de prototipo.
3. Implementar click-to-move, cursor a mundo, zoom, interacción y evasión.
4. Medir sensación con tres recorridos de usuario.

**Demo:** el jugador completa un circuito top-down, sortea obstáculos, interactúa con tres objetos, apunta una habilidad de área y no queda atascado.

### Hito 3 — Dos jugadores reales

1. Mover el gimnasio a servidor autoritativo.
2. Conectar dos procesos cliente.
3. Simular latencia y desconexión.
4. Crear primera prueba multiproceso.

**Demo:** dos jugadores completan juntos el circuito desde un servidor dedicado.

Después de estos tres hitos se reestima el resto de la fase con datos reales.

## 14. Decisiones que deben confirmarse antes de cerrar la Sección 2

- Control principal dentro de la vista top-down: click-to-move recomendado como baseline frente a movimiento directo con teclado.
- Cámara top-down fija o rotación limitada en incrementos; evitar rotación libre hasta demostrar que mejora la lectura.
- Reglas de selección: objetivo seleccionado, apuntado libre al cursor y prioridades cuando ambos coinciden.
- Estilo visual objetivo y hardware mínimo de PC.
- Tamaño y disponibilidad real del equipo.
- Modelo comercial futuro; no cambia la Fase 1, pero sí las restricciones de economía posteriores.
- Tono y audiencia por edades.
- Nombre definitivo del mundo y del sistema de poder tras búsqueda de marcas.

Estas decisiones no impiden comenzar la Sección 0 ni la preparación segura de la Sección 1.
