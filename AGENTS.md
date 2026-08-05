# Instrucciones operativas para agentes

Estas reglas se aplican a todo el repositorio de Animus Awakening.

## Precedencia

1. Políticas de plataforma y seguridad.
2. Instrucción explícita vigente de Gabriel.
3. Este `AGENTS.md` y `Docs/Team/TEAM_CHARTER.md`.
4. ADR aprobados y `Docs/Team/CURRENT_STATE.md`.
5. Plan de Fase 1 y tarjeta de trabajo activa.
6. Instrucciones específicas del perfil de agente.

Ante una contradicción material, detener el área afectada y escalar al orquestador. Gabriel conserva la decisión final de producto, alcance y publicación.

## Contexto fijo actual

- Unreal Engine 5.8, PC.
- MMORPG vertical slice para 2–8 jugadores.
- Cámara top-down elevada; click-to-move es el baseline a comparar con teclado.
- Servidor dedicado autoritativo.
- Mundo por zonas abiertas e instancias.
- C++ para reglas críticas; Blueprints para presentación/configuración.
- Plan fuente: `Docs/Planning/FASE_1_VERTICAL_SLICE_MMO.md`.

No copiar propiedad intelectual protegida. La inspiración debe traducirse a mundo, nombres, personajes, poderes, iconografía, narrativa y reglas originales.

## Inicio obligatorio de toda tarea

1. Leer `Docs/Team/CURRENT_STATE.md` y la tarjeta asignada.
2. Confirmar commit base con `git status --short --branch` y `git rev-parse HEAD`.
3. Identificar rutas autorizadas, contratos compartidos y suites requeridas.
4. Confirmar que ningún otro agente posee esas rutas.
5. Para `.uasset`, `.umap`, External Actors o editor/MCP, confirmar lease y lock LFS.
6. Si la memoria compartida está disponible, leer `C:/Users/Gabriel/Documents/claude obsidian/claude/CLAUDE.md` y la página de Animus Awakening. Solo el orquestador la modifica.

## Autoridad y Git

- Los especialistas no ejecutan commit, push, pull, merge, rebase, stash, cambio de rama, tag o release salvo delegación explícita del orquestador en la tarea actual.
- Solo el orquestador integra resultados y actualiza memoria.
- Push o merge a `main`, tags, builds públicas y releases requieren autorización explícita de Gabriel para esa tanda.
- No borrar, sobrescribir masivamente, migrar datos ni cambiar servicios externos sin aprobación.
- Nunca incluir secretos. Detenerse si aparece una credencial o un archivo sensible.
- Preservar cambios ajenos y no revertirlos automáticamente.

## Propiedad y Unreal

- Un archivo o patrón de ruta tiene un único propietario por tanda.
- `.uproject`, `Config/`, `*.Build.cs`, `*.Target.cs`, Gameplay Tags centrales, contratos y migraciones son compartidos críticos: requieren lease del orquestador.
- `.uasset` y `.umap` son binarios lockable: no se fusionan manualmente.
- Un mapa incluye su `.umap`, `__ExternalActors__`, `__ExternalObjects__`, Data Layers, HLOD y navegación asociada.
- Solo un agente puede poseer escritura del editor/MCP por tanda. Evitar `Save All`; guardar únicamente paquetes declarados.
- Renombres y movimientos de assets se hacen desde Unreal, seguidos de Fix Up Redirectors y validación de referencias.
- Si Unreal guarda paquetes inesperados, detenerse y reportar; no descartar cambios automáticamente.
- El contenido nuevo debe preferir `Content/Animus/`. Las carpetas TopDown, Variant_Strategy y Variant_TwinStick son plantilla de referencia hasta una decisión explícita.
- No colocar autoridad, daño, inventario, economía o persistencia crítica en Level Blueprint.

## Verificación y entrega

- Aplicar la suite nueva y todas las regresiones acumulativas correspondientes R0–R9.
- Gameplay, red o autoridad requieren validación con servidor dedicado cuando exista el target.
- Cambios reflejados en UCLASS, UPROPERTY, RPC o estructuras requieren build completa; Live Coding no es evidencia suficiente.
- No afirmar que un test pasó si no se ejecutó.
- La entrega usa `Docs/Team/TASK_TEMPLATE.md` y distingue VALIDADO, NO VALIDADO y BLOQUEADO.
- Solo el orquestador puede marcar una tarea integrada o un hito cerrado.

## Memoria y continuidad

- Ninguna decisión durable debe existir únicamente en el chat.
- El orquestador actualiza `Docs/Team/CURRENT_STATE.md`, ADR/documentos afectados y la memoria Obsidian tras integrar.
- Los especialistas entregan un bloque de relevo; no escriben directamente en memoria para evitar conflictos.

