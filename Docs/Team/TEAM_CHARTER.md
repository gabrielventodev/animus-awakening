# Carta del equipo multiagente

**Estado:** activo  
**Proyecto:** Animus Awakening  
**Autoridad final:** Gabriel  
**Integrador:** Codex principal  
**Concurrencia:** máximo tres subagentes además del orquestador

## 1. Jerarquía

### Gabriel — Director

Decide visión, alcance, prioridades, experiencia del jugador, lore, propiedad intelectual, economía macro, presupuesto, servicios externos y releases. Puede aceptar o rechazar cualquier propuesta.

### Codex principal — Orquestador e integrador

Descompone hitos, crea tarjetas, asigna propietarios, controla dependencias, dirige especialistas, revisa diffs, ejecuta gates, integra cambios y actualiza documentación y memoria. Es el único que declara una tarea integrada o un hito cerrado.

### Especialistas

| Perfil | Responsabilidad | Modo normal |
|---|---|---|
| `unreal_gameplay` | Top-down, controles, combate, GAS, IA, C++/Blueprint | Escritura acotada |
| `unreal_world_builder` | Mapas, World Partition, Data Layers, navegación y graybox | Escritura con lease binario/editor |
| `ui_presentation` | HUD, UMG, animación, VFX, audio y accesibilidad | Escritura con lease binario/editor |
| `netcode_persistence` | Servidor dedicado, replicación, backend, PostgreSQL, seguridad | Escritura acotada |
| `world_economy` | Mundo, progresión, misiones, loot y balance | Solo lectura/consultivo |
| `qa_release_guard` | Pruebas, regresiones, build, rendimiento y evidencia | Solo lectura/independiente |

Los perfiles son configuraciones invocables, no procesos residentes. Se activan por tareas acotadas. Al haber cuatro espacios totales contando al orquestador, solo tres especialistas trabajan simultáneamente; QA normalmente entra en una segunda tanda.

## 2. Matriz de autoridad

| Acción | Especialista | Orquestador | Gabriel |
|---|---|---|---|
| Leer, investigar, diagnosticar | Autónomo | Autónomo | Informado |
| Editar rutas asignadas por una tarjeta aprobada | Autónomo | Supervisa | Informado |
| Añadir pruebas/documentación dentro del alcance | Autónomo | Supervisa | Informado |
| Ejecutar validaciones no destructivas | Autónomo | Autónomo | Informado |
| Tocar rutas fuera del lease | Consulta | Autoriza/reasigna | Informado |
| Cambiar contrato o configuración compartida | Propone | Evalúa | Aprueba si es arquitectónico |
| Cambiar arquitectura, stack, protocolo o esquema | Propone | Recomienda | Aprueba |
| Cambiar alcance, diseño, lore, economía macro o IP | Propone | Recomienda | Aprueba |
| Añadir plugins, servicios, dependencias o licencias | Propone | Audita | Aprueba |
| Borrar, migrar o sobrescribir materialmente | Prohibido sin orden | Prepara plan reversible | Aprueba |
| Commit local de integración | No | Permitido dentro de alcance aprobado | Informado |
| Push/merge a `main`, tag o release | No | Prepara | Aprueba la tanda |
| Omitir pruebas o aceptar regresión | No | No | Solo como riesgo explícito documentado |

Ante duda se usa el nivel superior de autoridad.

## 3. Contrato de asignación

Antes de escribir, el orquestador registra en una tarjeta:

- ID y objetivo observable.
- Especialista propietario.
- Commit base.
- Rutas o patrones exactos con permiso de escritura.
- Archivos compartidos y leases necesarios.
- Dependencias y decisiones ya aprobadas.
- Criterios de aceptación.
- Suites y evidencia requeridas.
- Acciones prohibidas o pendientes de Gabriel.

No hay propietarios simultáneos sobre la misma ruta. Los cambios no asignados son solo lectura.

## 4. Leases, locks y editor

- `.uasset` y `.umap` usan Git LFS y atributo `lockable`.
- El orquestador mantiene la tabla de leases en `CURRENT_STATE.md`.
- Antes de editar un binario se obtiene lock; después de integrar se libera.
- World Partition se divide por mapa, región o Data Layer explícita; One File Per Actor no vuelve seguros los merges binarios.
- Un solo agente posee escritura del editor y MCP por tanda.
- Ninguna automatización modificadora corre en paralelo con otra.
- Se registra `git status` antes y después de usar editor/MCP.

## 5. Gates de integración

| Gate | Condición |
|---|---|
| G0 Ready | Alcance, propietario, rutas, dependencias y tests definidos |
| G1 Lease | Worktree conocido, LFS disponible, locks y editor asignados |
| G2 Autor | Compilación/prueba nueva y validación específica ejecutadas |
| G3 Revisión | Diff dentro de alcance, contratos y autoridad revisados |
| G4 Integración | Build/cook/asset validation aplicable, LFS y regresión acumulativa |
| G5 Hito | Dedicated/E2E, evidencia, memoria y aprobación de Gabriel cuando corresponda |

`Listo para revisión` no significa `Hecho`. Solo el orquestador puede cerrar tras G3/G4; un hito requiere G5.

## 6. Escalamiento inmediato

Detener el área afectada si existe:

- Pérdida o duplicación de objetos, divisas o progreso.
- Autoridad crítica confiada al cliente.
- Crash, corrupción, credenciales o vulnerabilidad.
- Conflicto de archivos o estado Git de origen desconocido.
- Cambio de alcance, arquitectura, propiedad intelectual o costo externo.
- Dos intentos fallidos sobre el mismo bloqueo.

Formato de escalamiento:

```text
Severidad:
Decisión requerida:
Contexto mínimo:
Evidencia:
Opciones:
Recomendación:
Impacto de esperar:
```

## 7. Definition of Done

Una tarea termina cuando cumple criterios, no contiene cambios fuera de alcance, tiene pruebas y regresiones aplicables, no agrega errores de log, valida assets modificados, documenta contratos/decisiones, aporta evidencia reproducible, fue revisada por el orquestador y deja un relevo exacto. Si afecta gameplay/red se valida en servidor dedicado cuando esté disponible. La memoria se actualiza después de integrar.

## 8. Fuentes durables y continuidad

Orden de evidencia del estado real:

1. Repositorio `HEAD`, archivos y resultados reproducibles.
2. ADR y documentos aprobados.
3. `Docs/Team/CURRENT_STATE.md`.
4. Memoria Obsidian de Animus Awakening.
5. Conversación.

La dirección vigente del producto está en `Docs/Planning/FASE_1_VERTICAL_SLICE_MMO.md`. Ninguna decisión importante debe vivir solo en una conversación.
